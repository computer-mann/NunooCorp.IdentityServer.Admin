// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Events.Identity
{
    public class RoleDeletedEvent<TRoleDto> : AuditEvent
    {
        public TRoleDto Role { get; set; }

        public RoleDeletedEvent(TRoleDto role)
        {
            Role = role;
        }
    }
}