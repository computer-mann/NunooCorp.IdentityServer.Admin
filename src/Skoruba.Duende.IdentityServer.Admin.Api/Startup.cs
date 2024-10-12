﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using PrinceHarry.AuditLogging.EntityFramework.Entities;
using PrinceHarry.Duende.IdentityServer.Admin.Api.Configuration;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Extensions;
using PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.Extensions;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared.DbContexts;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared.Entities.Identity;
using PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared.Extensions;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Configuration;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Configuration.Authorization;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.ExceptionHandling;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Helpers;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Mappers;
using PrinceHarry.Duende.IdentityServer.Admin.UI.Api.Resources;
using PrinceHarry.Duende.IdentityServer.Shared.Configuration.Helpers;
using PrinceHarry.Duende.IdentityServer.Shared.Dtos;
using PrinceHarry.Duende.IdentityServer.Shared.Dtos.Identity;

namespace PrinceHarry.Duende.IdentityServer.Admin.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var adminApiConfiguration = Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
            services.AddSingleton(adminApiConfiguration);
            
            // Add DbContexts
            RegisterDbContexts(services);
            
            // Add email senders which is currently setup for SendGrid and SMTP
            services.AddEmailSenders(Configuration);
   
            // Add authentication services
            RegisterAuthentication(services);

            // Add authorization services
            RegisterAuthorization(services);
            
            services.AddIdentityServerAdminApi<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext,AdminLogDbContext, AdminAuditLogDbContext, AuditLog,
                IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole,
                UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
                IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
                IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(Configuration, adminApiConfiguration);

            services.AddSwaggerServices(adminApiConfiguration);
            
            services.AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext>(Configuration, adminApiConfiguration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdminApiConfiguration adminApiConfiguration)
        {
            app.AddForwardHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(settings =>
            {
                settings.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = adminApiConfiguration.OidcSwaggerUIClientId,
                    AppName = adminApiConfiguration.ApiName,
                    UsePkceWithAuthorizationCodeGrant = true,
                    ClientSecret = null
                };
            });

            app.UseRouting();
            UseAuthentication(app);
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }

        public virtual void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext, AuditLog>(Configuration);
        }

        public virtual void RegisterAuthentication(IServiceCollection services)
        {
            services.AddApiAuthentication<AdminIdentityDbContext, UserIdentity, UserIdentityRole>(Configuration);
        }

        public virtual void RegisterAuthorization(IServiceCollection services)
        {
            services.AddAuthorizationPolicies();
        }

        public virtual void UseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
