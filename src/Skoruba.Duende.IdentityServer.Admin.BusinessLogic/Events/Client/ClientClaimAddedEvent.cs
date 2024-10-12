// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.AuditLogging.Events;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Configuration;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Events.Client
{
    public class ClientClaimAddedEvent : AuditEvent
    {
        public ClientClaimsDto ClientClaim { get; set; }

        public ClientClaimAddedEvent(ClientClaimsDto clientClaim)
        {
            ClientClaim = clientClaim;
        }
    }
}