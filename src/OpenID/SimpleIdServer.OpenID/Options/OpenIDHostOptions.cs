﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleIdServer.OpenID.SubjectTypeBuilders;

namespace SimpleIdServer.OpenID.Options
{
    public class OpenIDHostOptions
    {
        public OpenIDHostOptions()
        {
            DefaultSubjectType = PublicSubjectTypeBuilder.SUBJECT_TYPE;
            DefaultMaxAge = null;
            DefaultAcrValue = "sid-load-01";
            AuthenticationScheme = "MultiAccount";
            CookieName = CookieAuthenticationDefaults.CookiePrefix + AuthenticationScheme;
            SessionCookieName = CookieAuthenticationDefaults.CookiePrefix + "Session";
            IsRedirectionUrlHTTPSRequired = true;
            IsInitiateLoginUriHTTPSRequired = true;
            IsLocalhostAllowed = false;
            MaxBindingMessageSize = 150;
            AuthRequestExpirationTimeInSeconds = 120;
            BlockThreadMS = 2 * 1000;
            FcmTitle = "Authenticate";
            FcmBody = "SimpleIdServer wants to authenticate";
            DefaultBCAuthorizeWaitIntervalInSeconds = 2;
        }

        /// <summary>
        /// OAUTH2.0 client's default subject type.
        /// </summary>
        public string DefaultSubjectType { get; set; }
        /// <summary>
        ///  OAUTH2.0 client's default max age in seconds.
        /// </summary>
        public double? DefaultMaxAge { get; set; }
        /// <summary>
        /// Default ACR value.
        /// </summary>
        public string DefaultAcrValue { get; set; }
        /// <summary>
        /// Cookie name.
        /// </summary>
        public string CookieName { get; set; }
        /// <summary>
        /// Authentication scheme.
        /// </summary>
        public string AuthenticationScheme { get; set; }
        /// <summary>
        /// Session cookie name.
        /// </summary>
        public string SessionCookieName { get; set; }
        /// <summary>
        /// Check if the redirection url must be HTTPS.
        /// </summary>
        public bool IsRedirectionUrlHTTPSRequired { get; set; }
        /// <summary>
        /// Check if the redirection url can contains localhost.
        /// </summary>
        public bool IsLocalhostAllowed { get; set; }
        /// <summary>
        /// Check if 'initiate_login_uri' must be HTTPS.
        /// </summary>
        public bool IsInitiateLoginUriHTTPSRequired { get; set; }
        /// <summary>
        /// Check if 'mutual-tls' is enabled.
        /// Configure the 'mutual-tls' with CERTIFICATE in STARTUP
        /// https://docs.identityserver.io/en/3.1.0/topics/mtls.html
        /// </summary>
        public bool IsMutualTlsEnabled { get; set; }
        /// <summary>
        /// Maximum number of characters for the "binding_message".
        /// </summary>
        public int MaxBindingMessageSize { get; set; }
        /// <summary>
        /// Set the FCM title.
        /// </summary>
        public string FcmTitle { get; set; }
        /// <summary>
        /// Set the FCM body.
        /// </summary>
        public string FcmBody { get; set; }
        /// <summary>
        /// Expiration time auth_req_id in seconds.
        /// </summary>
        public int AuthRequestExpirationTimeInSeconds { get; set; }
        /// <summary>
        /// Time to block the job in MS.
        /// </summary>
        public int BlockThreadMS { get; set; }
        /// <summary>
        /// Default interval in seconds.
        /// </summary>
        public int DefaultBCAuthorizeWaitIntervalInSeconds { get; set; }
    }
}
