﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.ApiResources
{
    public class ApiSecretsApiDto
    {
        public ApiSecretsApiDto()
        {
            ApiSecrets = new List<ApiSecretApiDto>();
        }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<ApiSecretApiDto> ApiSecrets { get; set; }
    }
}