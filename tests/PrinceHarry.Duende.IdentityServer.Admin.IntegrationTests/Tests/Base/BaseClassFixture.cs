// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using PrinceHarry.Duende.IdentityServer.Admin.IntegrationTests.Common;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Configuration;
using Xunit;

namespace PrinceHarry.Duende.IdentityServer.Admin.IntegrationTests.Tests.Base
{
    public class BaseClassFixture : IClassFixture<TestFixture>
    {
        protected readonly HttpClient Client;
        protected readonly TestServer TestServer;

        public BaseClassFixture(TestFixture fixture)
        {
            Client = fixture.Client;
            TestServer = fixture.TestServer;
        }

        protected virtual void SetupAdminClaimsViaHeaders()
        {
            using (var scope = TestServer.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<AdminConfiguration>();
                Client.SetAdminClaimsViaHeaders(configuration);
            }
        }
    }
}