﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.DTOs;
using SimpleIdServer.IdServer.Exceptions;
using SimpleIdServer.IdServer.Helpers;
using SimpleIdServer.IdServer.Jwt;
using SimpleIdServer.IdServer.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Api.Authorization.Validators
{
    public class OAuthAuthorizationRequestValidator : IAuthorizationRequestValidator
    {
        private readonly IAmrHelper _amrHelper;
        private readonly IExtractRequestHelper _extractRequestHelper;
        private readonly IEnumerable<IOAuthResponseMode> _oauthResponseModes;
        private readonly IClientHelper _clientHelper;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly IdServerHostOptions _options;

        public OAuthAuthorizationRequestValidator(IAmrHelper amrHelper, 
            IExtractRequestHelper extractRequestHelper, IEnumerable<IOAuthResponseMode> oauthResponseModes, IClientHelper clientHelper, IJwtBuilder jwtBuilder, IOptions<IdServerHostOptions> options)
        {
            _amrHelper = amrHelper;
            _extractRequestHelper = extractRequestHelper;
            _oauthResponseModes = oauthResponseModes;
            _clientHelper = clientHelper;
            _jwtBuilder = jwtBuilder;
            _options = options.Value;
        }

        public virtual async Task Validate(GrantRequest request, HandlerContext context, CancellationToken cancellationToken)
        {
            var openidClient = context.Client;
            var clientId = context.Request.RequestData.GetClientIdFromAuthorizationRequest();
            var scopes = request.Scopes;
            var acrValues = context.Request.RequestData.GetAcrValuesFromAuthorizationRequest();
            var prompt = context.Request.RequestData.GetPromptFromAuthorizationRequest();
            var claims = context.Request.RequestData.GetClaimsFromAuthorizationRequest();
            var resources = context.Request.RequestData.GetResourcesFromAuthorizationRequest();
            if (!request.Scopes.Any() && !request.Audiences.Any())
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETERS, $"{AuthorizationRequestParameters.Scope},{AuthorizationRequestParameters.Resource}"));

            var unsupportedScopes = scopes.Where(s => s != Constants.StandardScopes.OpenIdScope.Name && !context.Client.Scopes.Any(sc => sc.Name == s));
            if (unsupportedScopes.Any())
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.UNSUPPORTED_SCOPES, string.Join(",", unsupportedScopes)));

            if (context.User == null)
            {
                if (prompt == PromptParameters.None)
                    throw new OAuthException(ErrorCodes.LOGIN_REQUIRED, ErrorMessages.LOGIN_IS_REQUIRED);

                throw new OAuthLoginRequiredException(await GetFirstAmr(context.Realm, acrValues, claims, openidClient, cancellationToken));
            }

            var activeSession = context.User.GetActiveSession(context.Realm ?? Constants.DefaultRealm);
            if (activeSession == null)
                throw new OAuthLoginRequiredException(await GetFirstAmr(context.Realm, acrValues, claims, openidClient, cancellationToken), true);

            await _extractRequestHelper.Extract(context);
            await CommonValidate(context, cancellationToken);
            var responseTypes = context.Request.RequestData.GetResponseTypesFromAuthorizationRequest();
            var nonce = context.Request.RequestData.GetNonceFromAuthorizationRequest();
            var redirectUri = context.Request.RequestData.GetRedirectUriFromAuthorizationRequest();
            var maxAge = context.Request.RequestData.GetMaxAgeFromAuthorizationRequest();
            var idTokenHint = context.Request.RequestData.GetIdTokenHintFromAuthorizationRequest();
            if (string.IsNullOrWhiteSpace(redirectUri))
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, AuthorizationRequestParameters.RedirectUri));

            if (responseTypes.Contains(TokenResponseParameters.IdToken) && string.IsNullOrWhiteSpace(nonce))
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, AuthorizationRequestParameters.Nonce));

            if (maxAge != null)
            {
                if (DateTime.UtcNow > activeSession.AuthenticationDateTime.AddSeconds(maxAge.Value))
                    throw new OAuthLoginRequiredException(await GetFirstAmr(context.Realm, acrValues, claims, openidClient, cancellationToken));
            }
            else if (openidClient.DefaultMaxAge != null && DateTime.UtcNow > activeSession.AuthenticationDateTime.AddSeconds(openidClient.DefaultMaxAge.Value))
                throw new OAuthLoginRequiredException(await GetFirstAmr(context.Realm, acrValues, claims, openidClient, cancellationToken));

            if (!string.IsNullOrWhiteSpace(idTokenHint))
            {
                var payload = ExtractIdTokenHint(context.Realm, idTokenHint);
                if (context.User.Name != payload.Subject)
                    throw new OAuthException(ErrorCodes.INVALID_REQUEST, ErrorMessages.INVALID_SUBJECT_IDTOKENHINT);

                if (!payload.Audiences.Contains(context.GetIssuer()))
                    throw new OAuthException(ErrorCodes.INVALID_REQUEST, ErrorMessages.INVALID_AUDIENCE_IDTOKENHINT);
            }

            if (context.Client.IsResourceParameterRequired && !resources.Any())
                throw new OAuthException(ErrorCodes.INVALID_TARGET, string.Format(ErrorMessages.MISSING_PARAMETER, AuthorizationRequestParameters.Resource));
            CheckGrantIdAndAction(context);

            switch (prompt)
            {
                case PromptParameters.Login:
                    throw new OAuthLoginRequiredException(await GetFirstAmr(context.Realm, acrValues, claims, openidClient, cancellationToken));
                case PromptParameters.Consent:
                    RedirectToConsentView(context);
                    break;
                case PromptParameters.SelectAccount:
                    throw new OAuthSelectAccountRequiredException();
            }

            if (!context.User.HasOpenIDConsent(context.Realm, clientId, request, claims))
            {
                RedirectToConsentView(context);
            }

            if (claims != null)
            {
                var idtokenClaims = claims.Where(cl => cl.Type == AuthorizationClaimTypes.IdToken && cl.IsEssential && Constants.AllUserClaims.Contains(cl.Name));
                var invalidClaims = idtokenClaims.Where(icl => !context.User.Claims.Any(cl => cl.Type == icl.Name && (icl.Values == null || !icl.Values.Any() || icl.Values.Contains(cl.Value))));
                if (invalidClaims.Any())
                    throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.INVALID_CLAIMS, string.Join(",", invalidClaims.Select(i => i.Name))));
            }
        }

        protected void CheckGrantIdAndAction(HandlerContext context)
        {
            var grantId = context.Request.RequestData.GetGrantIdFromAuthorizationRequest();
            var grantManagementAction = context.Request.RequestData.GetGrantManagementActionFromAuthorizationRequest();
            if (_options.GrantManagementActionRequired && string.IsNullOrWhiteSpace(grantManagementAction))
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, AuthorizationRequestParameters.GrantManagementAction));

            if (!string.IsNullOrWhiteSpace(grantManagementAction) && !Constants.AllStandardGrantManagementActions.Contains(grantManagementAction))
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.INVALID_GRANT_MANAGEMENT_ACTION, grantManagementAction));

            if (!string.IsNullOrWhiteSpace(grantId) && grantManagementAction == Constants.StandardGrantManagementActions.Create)
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, ErrorMessages.GRANT_ID_CANNOT_BE_SPECIFIED);

            if (!string.IsNullOrWhiteSpace(grantId) && string.IsNullOrWhiteSpace(grantManagementAction))
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.MISSING_PARAMETER, AuthorizationRequestParameters.GrantManagementAction));
        }

        protected virtual void RedirectToConsentView(HandlerContext context)
        {
            if (context.Client.IsConsentDisabled) return;
            throw new OAuthUserConsentRequiredException();
        }

        protected async Task CommonValidate(HandlerContext context, CancellationToken cancellationToken)
        {
            var client = context.Client;
            var redirectUri = context.Request.RequestData.GetRedirectUriFromAuthorizationRequest();
            var responseTypes = context.Request.RequestData.GetResponseTypesFromAuthorizationRequest();
            var responseMode = context.Request.RequestData.GetResponseModeFromAuthorizationRequest();
            var unsupportedResponseTypes = responseTypes.Where(t => !client.ResponseTypes.Contains(t));
            var redirectionUrls = await _clientHelper.GetRedirectionUrls(client, cancellationToken);
            if (!string.IsNullOrWhiteSpace(redirectUri) && !redirectionUrls.Any(r =>
            {
                var regex = new Regex(r);
                return regex.Match(redirectUri).Success;
            })) throw new OAuthExceptionBadRequestURIException(redirectUri);

            if (!string.IsNullOrWhiteSpace(responseMode) && !_oauthResponseModes.Any(o => o.ResponseMode == responseMode)) throw new OAuthException(ErrorCodes.INVALID_REQUEST, string.Format(ErrorMessages.BAD_RESPONSE_MODE, responseMode));

            if (unsupportedResponseTypes.Any()) throw new OAuthException(ErrorCodes.UNSUPPORTED_RESPONSE_TYPE, string.Format(ErrorMessages.BAD_RESPONSE_TYPES_CLIENT, string.Join(",", unsupportedResponseTypes)));
        }

        protected async Task<string> GetFirstAmr(string realm, IEnumerable<string> acrValues, IEnumerable<AuthorizedClaim> claims, Client client, CancellationToken cancellationToken)
        {
            var acr = await _amrHelper.FetchDefaultAcr(realm, acrValues, claims, client, cancellationToken);
            if (acr == null)
                return null;

            return acr.AuthenticationMethodReferences.First();
        }

        protected JsonWebToken ExtractIdTokenHint(string realm, string idTokenHint)
        {
            var extractionResult = _jwtBuilder.ReadSelfIssuedJsonWebToken(realm, idTokenHint);
            if (extractionResult.Error != null)
                throw new OAuthException(ErrorCodes.INVALID_REQUEST, extractionResult.Error);
            return extractionResult.Jwt;
        }
    }
}