﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantIdentityDeletedEvent : AuditEvent
    {
        public string Key { get; set; }

        public PersistedGrantIdentityDeletedEvent(string key)
        {
            Key = key;
        }
    }
}