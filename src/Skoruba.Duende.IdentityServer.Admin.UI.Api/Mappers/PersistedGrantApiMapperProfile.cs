// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.PersistedGrants;

namespace PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers
{
    public class PersistedGrantApiMapperProfile : Profile
    {
        public PersistedGrantApiMapperProfile()
        {
            CreateMap<PersistedGrantDto, PersistedGrantApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantDto, PersistedGrantSubjectApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantsApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantSubjectsApiDto>(MemberList.Destination);
        }
    }
}