﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserProviderRequestedEvent<TUserProviderDto> : AuditEvent
    {
        public TUserProviderDto Provider { get; set; }

        public UserProviderRequestedEvent(TUserProviderDto provider)
        {
            Provider = provider;
        }
    }
}