﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Configuration;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertyDeletedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperty { get; set; }

        public IdentityResourcePropertyDeletedEvent(IdentityResourcePropertiesDto identityResourceProperty)
        {
            IdentityResourceProperty = identityResourceProperty;
        }
    }
}