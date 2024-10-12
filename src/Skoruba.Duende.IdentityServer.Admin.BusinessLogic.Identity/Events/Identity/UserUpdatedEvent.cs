// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserUpdatedEvent<TUserDto> : AuditEvent
    {
        public TUserDto OriginalUser { get; set; }
        public TUserDto User { get; set; }

        public UserUpdatedEvent(TUserDto originalUser, TUserDto user)
        {
            OriginalUser = originalUser;
            User = user;
        }
    }
}