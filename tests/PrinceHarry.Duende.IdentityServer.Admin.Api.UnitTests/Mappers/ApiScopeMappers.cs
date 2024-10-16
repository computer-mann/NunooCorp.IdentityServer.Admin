﻿using FluentAssertions;
using PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mocks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Configuration;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.ApiScopes;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.UnitTests.Mocks;
using Xunit;

namespace PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mappers
{
    public class ApiScopeMappers
    {
        [Fact]
        public void CanMapApiScopeApiDtoToApiScopeDto()
        {
            var apiScopeApiDto = ApiScopeApiDtoMock.GenerateRandomApiScope(1);

            var apiScopeDto = apiScopeApiDto.ToApiScopeApiModel<ApiScopeDto>();

            apiScopeDto.Should().BeEquivalentTo(apiScopeApiDto, options => options.Excluding(x=> x.ApiScopeProperties));
        }
        
        [Fact]
        public void CanMapApiScopeDtoToApiScopeApiDto()
        {
            var apiScopeDto = ApiScopeDtoMock.GenerateRandomApiScope(1);

            var apiScopeApiDto = apiScopeDto.ToApiScopeApiModel<ApiScopeApiDto>();

            apiScopeApiDto.Should().BeEquivalentTo(apiScopeDto, options => options
                .Excluding(x => x.ApiScopeProperties)
                .Excluding(x=> x.UserClaimsItems));
        }

        [Fact]
        public void CanMapApiScopePropertyApiDtoToApiScopePropertyDto()
        {
            var apiScopePropertyApiDto = ApiScopeApiDtoMock.GenerateRandomApiScopeProperty(1);

            var apiScopePropertyDto = apiScopePropertyApiDto.ToApiScopeApiModel<ApiScopePropertyDto>();

            apiScopePropertyDto.Should().BeEquivalentTo(apiScopePropertyApiDto);
        }

        [Fact]
        public void CanMapApiScopePropertyDtoToApiScopePropertyDto()
        {
            var apiScopePropertyDto = ApiScopeDtoMock.GenerateRandomApiScopeProperty(1,1);

            var apiScopePropertyApiDto = apiScopePropertyDto.ToApiScopeApiModel<ApiScopePropertyApiDto>();

            apiScopePropertyApiDto.Should().BeEquivalentTo(apiScopePropertyDto, options =>
                options.Excluding(x => x.ApiScopeId)
                    .Excluding(x => x.ApiScopeName)
                    .Excluding(x => x.PageSize)
                    .Excluding(x => x.TotalCount)
                    .Excluding(x => x.ApiScopePropertyId)
                    .Excluding(x => x.ApiScopeProperties));
        }
    }
}