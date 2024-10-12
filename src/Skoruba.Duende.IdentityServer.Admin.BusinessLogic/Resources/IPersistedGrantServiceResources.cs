// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Helpers;

namespace PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Resources
{
    public interface IPersistedGrantServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
