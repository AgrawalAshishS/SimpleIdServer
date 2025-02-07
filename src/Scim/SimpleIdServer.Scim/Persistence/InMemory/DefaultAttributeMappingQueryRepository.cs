﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.Scim.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleIdServer.Scim.Persistence.InMemory
{
    public class DefaultAttributeMappingQueryRepository : ISCIMAttributeMappingQueryRepository
    {
        private readonly List<SCIMAttributeMapping> _attributeMappingLst;

        public DefaultAttributeMappingQueryRepository(List<SCIMAttributeMapping> attributeMappingLst)
        {
            _attributeMappingLst = attributeMappingLst;
        }

        public Task<IEnumerable<SCIMAttributeMapping>> GetAll()
        {
            IEnumerable<SCIMAttributeMapping> result = _attributeMappingLst;
            return Task.FromResult(result);
        }

        public Task<IEnumerable<SCIMAttributeMapping>> GetBySourceAttributes(IEnumerable<string> sourceAttributes)
        {
            return Task.FromResult(_attributeMappingLst.Where(a => sourceAttributes.Contains(a.SourceAttributeSelector)));
        }

        public Task<IEnumerable<SCIMAttributeMapping>> GetBySourceResourceType(string sourceResourceType)
        {
            return Task.FromResult(_attributeMappingLst.Where(a => a.SourceResourceType == sourceResourceType));
        }
    }
}
