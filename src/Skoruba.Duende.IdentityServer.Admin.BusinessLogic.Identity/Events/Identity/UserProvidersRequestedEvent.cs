﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserProvidersRequestedEvent<TUserProvidersDto> : AuditEvent
    {
        public TUserProvidersDto Providers { get; set; }

        public UserProvidersRequestedEvent(TUserProvidersDto providers)
        {
            Providers = providers;
        }
    }
}