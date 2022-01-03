﻿using CloudPharmacy.Logging.Configuration;
using CloudPharmacy.PharmacyStore.API.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace CloudPharmacy.PharmacyStore.API.Core.DependecyInjection
{
    internal static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApplicationInsightsConfiguration>(config.GetSection("ApplicationInsightsConfiguration"));
            services.AddSingleton<IValidateOptions<ApplicationInsightsConfiguration>, ApplicationInsightsConfigurationValidation>();
            var applicationInsightsConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationInsightsConfiguration>>().Value;
            services.AddSingleton<IApplicationInsightsConfiguration>(applicationInsightsConfiguration);

            services.Configure<CosmosDbConfiguration>(config.GetSection("CosmosDbConfiguration"));
            services.AddSingleton<IValidateOptions<CosmosDbConfiguration>, CosmosDbConfigurationValidation>();
            var cosmosDbConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<CosmosDbConfiguration>>().Value;
            services.AddSingleton<ICosmosDbConfiguration>(cosmosDbConfiguration);

            services.Configure<VerifiableCredentialsServiceConfiguration>(config.GetSection("VerifiableCredentialsServiceConfiguration"));
            services.AddSingleton<IValidateOptions<VerifiableCredentialsServiceConfiguration>, VerifiableCredentialsServiceConfigurationValidation>();
            var verifiableCredentialsServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<VerifiableCredentialsServiceConfiguration>>().Value;
            services.AddSingleton<IVerifiableCredentialsServiceConfiguration>(verifiableCredentialsServiceConfiguration);

            return services;
        }
    }
}
