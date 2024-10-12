﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.ExceptionHandling;

namespace PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Resources
{
    public class ApiErrorResources : IApiErrorResources
    {
        public virtual ApiError CannotSetId()
        {
            return new ApiError
            {
                Code = nameof(CannotSetId),
                Description = ApiErrorResource.CannotSetId
            };
        }
    }
}