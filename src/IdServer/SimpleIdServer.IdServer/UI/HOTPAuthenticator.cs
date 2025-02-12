﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.Extensions.Options;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Options;

namespace SimpleIdServer.IdServer.UI
{
    public class HOTPAuthenticator : OTPAuthenticator, IOTPAuthenticator
    {
        private readonly IdServerHostOptions _options;

        public HOTPAuthenticator(IOptions<IdServerHostOptions> options)
        {
            _options = options.Value;
        }

        public OTPAlgs Alg => OTPAlgs.HOTP;

        public long GenerateOtp(UserCredential credential)
        {
            return GenerateOtp(credential.OTPKey, credential.OTPCounter);
        }

        public bool Verify(long otp, UserCredential credential)
        {
            var key = credential.OTPKey;
            for(long i = credential.OTPCounter - _options.HOTPWindow; i <= credential.OTPCounter; i++)
            {
                if (GenerateOtp(key, i) == otp)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
