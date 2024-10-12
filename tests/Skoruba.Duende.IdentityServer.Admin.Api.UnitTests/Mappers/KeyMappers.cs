using System;
using FluentAssertions;
using PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mocks;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Key;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.Key;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.UnitTests.Mocks;
using Xunit;

namespace PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mappers
{
    public class KeyMappers
    {
        [Fact]
        public void CanMapKeyDtoToKayApiDto()
        {
            var keyDto = KeyDtoMock.GenerateRandomKey(Guid.NewGuid().ToString());

            var keyApi = keyDto.ToKeyApiModel<KeyApiDto>();

            keyApi.Should().BeEquivalentTo(keyDto);
        }

        [Fact]
        public void CanMapKeyApiDtoToKeyDto()
        {
            var keyApiDto = KeyApiDtoMock.GenerateRandomKey(Guid.NewGuid().ToString());

            var keyDto = keyApiDto.ToKeyApiModel<KeyDto>();

            keyDto.Should().BeEquivalentTo(keyApiDto);
        }
    }
}