// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Key;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.Key;

namespace PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers
{
    public class KeyApiMapperProfile : Profile
    {
        public KeyApiMapperProfile()
        {
            CreateMap<KeyDto, KeyApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<KeysDto, KeysApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}