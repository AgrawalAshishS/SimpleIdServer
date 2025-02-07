﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using System.Collections.Generic;

namespace SimpleIdServer.IdServer.ExternalEvents
{
    public class TokenIssuedFailureEvent
    {
        public string ClientId { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public string GrantType { get; set; }
        public string Realm { get; set; }
        public string ErrorMessage { get; set; }
    }
}
