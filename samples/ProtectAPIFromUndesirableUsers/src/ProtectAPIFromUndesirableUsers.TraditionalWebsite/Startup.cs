﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ProtectAPIFromUndesirableUsers.TraditionalWebsite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddOpenIdConnect(options =>
                {
                    options.ClientId = TraditionalWebsiteConstants.CLIENT_ID;
                    options.ClientSecret = TraditionalWebsiteConstants.CLIENT_SECRET;
                    options.Authority = TraditionalWebsiteConstants.BASE_OPENID_URL;
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.SaveTokens = true;
                });
            services.AddAuthorization(options => options.AddPolicy("Authenticated", p => p.RequireAuthenticatedUser()));
            services.AddMvc(o =>
            {
                o.EnableEndpointRouting = false;
            }).AddNewtonsoftJson(o => { });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}