// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Configuration;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopePropertyAddedEvent : AuditEvent
    {
        public ApiScopePropertyAddedEvent(ApiScopePropertiesDto apiScopeProperty)
        {
            ApiScopeProperty = apiScopeProperty;
        }

        public ApiScopePropertiesDto ApiScopeProperty { get; set; }
    }
}