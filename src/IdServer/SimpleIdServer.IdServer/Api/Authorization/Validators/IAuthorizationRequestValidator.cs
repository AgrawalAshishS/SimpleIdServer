﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Api.Authorization.Validators
{
    public interface IAuthorizationRequestValidator
    {
        /// <summary>
        /// Validate the authorization request.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        Task Validate(GrantRequest grant, HandlerContext context, CancellationToken cancellationToken);
    }
}