using FluentAssertions;
using PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mocks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Configuration;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.IdentityResources;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.UnitTests.Mocks;
using Xunit;

namespace PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mappers
{
    public class IdentityResourceMappers
    {
        [Fact]
        public void CanMapIdentityResourceApiDtoToIdentityResourceDto()
        {
            var identityResourceApiDto = IdentityResourceApiDtoMock.GenerateRandomIdentityResource(1);

            var identityResourceDto = identityResourceApiDto.ToIdentityResourceApiModel<IdentityResourceDto>();

            identityResourceDto.Should().NotBeNull();

            identityResourceDto.Should().BeEquivalentTo(identityResourceApiDto);
        }

        [Fact]
        public void CanMapIdentityResourceDtoToIdentityResourceApiDto()
        {
            var identityResourceDto = IdentityResourceDtoMock.GenerateRandomIdentityResource(1);

            var identityResourceApiDto = identityResourceDto.ToIdentityResourceApiModel<IdentityResourceApiDto>();

            identityResourceApiDto.Should().BeEquivalentTo(identityResourceDto, options => options
                .Excluding(x => x.UserClaimsItems));
        }

        [Fact]
        public void CanMapIdentityResourcePropertyApiDtoToIdentityResourcePropertyDto()
        {
            var identityResourcePropertyApiDto = IdentityResourceApiDtoMock.GenerateRandomIdentityResourceProperty(1);

            var identityResourcePropertiesDto = identityResourcePropertyApiDto.ToIdentityResourceApiModel<IdentityResourcePropertiesDto>();

            identityResourcePropertyApiDto.Id.Should().Be(identityResourcePropertiesDto.IdentityResourcePropertyId);

            identityResourcePropertiesDto.Should().BeEquivalentTo(identityResourcePropertyApiDto, options => options.Excluding(x => x.Id));
        }

        [Fact]
        public void CanMapIdentityResourcePropertyDtoToIdentityResourcePropertyApiDto()
        {
            var identityResourcePropertyDto = IdentityResourceDtoMock.GenerateRandomIdentityResourceProperty(1, 1);

            var identityResourcePropertyApiDto = identityResourcePropertyDto.ToIdentityResourceApiModel<IdentityResourcePropertyApiDto>();

            identityResourcePropertyDto.IdentityResourcePropertyId.Should().Be(identityResourcePropertyApiDto.Id);

            identityResourcePropertyApiDto.Should().BeEquivalentTo(identityResourcePropertyDto, options =>
                options.Excluding(x => x.IdentityResourceId)
                    .Excluding(x => x.IdentityResourceName)
                    .Excluding(x => x.PageSize)
                    .Excluding(x => x.TotalCount)
                    .Excluding(x => x.IdentityResourcePropertyId)
                    .Excluding(x => x.IdentityResourceProperties));
        }
    }
}