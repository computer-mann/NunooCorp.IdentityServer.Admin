using System;
using FluentAssertions;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Dtos.PersistedGrants;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.UnitTests.Mocks;
using Xunit;

namespace PrinceHarry.Duende.IdentityServer.Admin.Api.UnitTests.Mappers
{
    public class PersistedGrantMappers
    {
        [Fact]
        public void CanMapPersistedGrantDtoToPersistedGrantSubjectsApiDto()
        {
            var persistedGrantDto = PersistedGrantDtoMock.GenerateRandomPersistedGrant(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var persistedGrantsDto = new PersistedGrantsDto();
            
            persistedGrantsDto.PersistedGrants.Add(persistedGrantDto);

            var persistedGrantSubjectsApiDto = persistedGrantsDto.ToPersistedGrantApiModel<PersistedGrantSubjectsApiDto>();

            persistedGrantSubjectsApiDto.Should().BeEquivalentTo(persistedGrantsDto, options => options.Excluding(x=> x.SubjectId));
        }

        [Fact]
        public void CanMapPersistedGrantDtoToPersistedGrantsApiDto()
        {
            var persistedGrantDto = PersistedGrantDtoMock.GenerateRandomPersistedGrant(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var persistedGrantsDto = new PersistedGrantsDto();

            persistedGrantsDto.PersistedGrants.Add(persistedGrantDto);

            var persistedGrantsApiDto = persistedGrantsDto.ToPersistedGrantApiModel<PersistedGrantsApiDto>();

            persistedGrantsApiDto.Should().BeEquivalentTo(persistedGrantsDto, options => options.Excluding(x => x.SubjectId));
        }

        [Fact]
        public void CanMapPersistedGrantDtoToPersistedGrantApiDto()
        {
            var persistedGrantDto = PersistedGrantDtoMock.GenerateRandomPersistedGrant(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var persistedGrantApiDto = persistedGrantDto.ToPersistedGrantApiModel<PersistedGrantApiDto>();

            persistedGrantApiDto.Should().BeEquivalentTo(persistedGrantDto, options => options.Excluding(x => x.SubjectId));
        }
    }
}