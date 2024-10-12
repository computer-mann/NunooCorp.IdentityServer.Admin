﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using PrinceHarry.Duende.IdentityServer.Shared.Configuration.Configuration.Common;
using PrinceHarry.Duende.IdentityServer.Shared.Configuration.Configuration.Email;
using PrinceHarry.Duende.IdentityServer.Shared.Configuration.Email;

namespace PrinceHarry.Duende.IdentityServer.Shared.Configuration.Helpers
{
    public static class StartupHelpers
    {
        /// <summary>
        /// Add email senders - configuration of sendgrid, smtp senders
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddEmailSenders(this IServiceCollection services, IConfiguration configuration)
        {
            var smtpConfiguration = configuration.GetSection(nameof(SmtpConfiguration)).Get<SmtpConfiguration>();
            var sendGridConfiguration = configuration.GetSection(nameof(SendGridConfiguration)).Get<SendGridConfiguration>();

            if (sendGridConfiguration != null && !string.IsNullOrWhiteSpace(sendGridConfiguration.ApiKey))
            {
                services.AddSingleton<ISendGridClient>(_ => new SendGridClient(sendGridConfiguration.ApiKey));
                services.AddSingleton(sendGridConfiguration);
                services.AddTransient<IEmailSender, SendGridEmailSender>();
            }
            else if (smtpConfiguration != null && !string.IsNullOrWhiteSpace(smtpConfiguration.Host))
            {
                services.AddSingleton(smtpConfiguration);
                services.AddTransient<IEmailSender, SmtpEmailSender>();
            }
            else
            {
                services.AddSingleton<IEmailSender, LogEmailSender>();
            }
        }

        public static void AddDataProtection<TDbContext>(this IServiceCollection services, IConfiguration configuration)
                    where TDbContext : DbContext, IDataProtectionKeyContext
        {
            AddDataProtection<TDbContext>(
                services,
                configuration.GetSection(nameof(DataProtectionConfiguration)).Get<DataProtectionConfiguration>(),
                configuration.GetSection(nameof(AzureKeyVaultConfiguration)).Get<AzureKeyVaultConfiguration>());
        }

        public static void AddDataProtection<TDbContext>(this IServiceCollection services, DataProtectionConfiguration dataProtectionConfiguration, AzureKeyVaultConfiguration azureKeyVaultConfiguration)
            where TDbContext : DbContext, IDataProtectionKeyContext
        {
            var dataProtectionBuilder = services.AddDataProtection()
                .SetApplicationName("PrinceHarry.Duende.IdentityServer")
                .PersistKeysToDbContext<TDbContext>();

            if (dataProtectionConfiguration.ProtectKeysWithAzureKeyVault)
            {
                if (azureKeyVaultConfiguration.UseClientCredentials)
                {
                    dataProtectionBuilder.ProtectKeysWithAzureKeyVault(
                        new Uri(azureKeyVaultConfiguration.DataProtectionKeyIdentifier),
                        new ClientSecretCredential(azureKeyVaultConfiguration.TenantId,
                            azureKeyVaultConfiguration.ClientId, azureKeyVaultConfiguration.ClientSecret));
                }
                else
                {
                    dataProtectionBuilder.ProtectKeysWithAzureKeyVault(new Uri(azureKeyVaultConfiguration.DataProtectionKeyIdentifier), new DefaultAzureCredential());
                }
            }
        }

        public static void AddAzureKeyVaultConfiguration(this IConfiguration configuration, IConfigurationBuilder configurationBuilder)
        {
            if (configuration.GetSection(nameof(AzureKeyVaultConfiguration)).Exists())
            {
                var azureKeyVaultConfiguration = configuration.GetSection(nameof(AzureKeyVaultConfiguration)).Get<AzureKeyVaultConfiguration>();

                if (azureKeyVaultConfiguration.ReadConfigurationFromKeyVault)
                {
                    if (azureKeyVaultConfiguration.UseClientCredentials)
                    {
                        configurationBuilder.AddAzureKeyVault(new Uri(azureKeyVaultConfiguration.AzureKeyVaultEndpoint),
                            new ClientSecretCredential(azureKeyVaultConfiguration.TenantId,
                                azureKeyVaultConfiguration.ClientId, azureKeyVaultConfiguration.ClientSecret));
                    }
                    else
                    {
                        configurationBuilder.AddAzureKeyVault(new Uri(azureKeyVaultConfiguration.AzureKeyVaultEndpoint),
                            new DefaultAzureCredential());
                    }
                }
            }
        }
    }
}
