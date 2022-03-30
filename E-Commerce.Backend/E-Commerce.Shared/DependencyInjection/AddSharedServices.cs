﻿using E_Commerce.Shared.Services.Implementations;
using E_Commerce.Shared.Services.Implementations.Base64FileValidator;
using E_Commerce.Shared.Services.Interfaces;
using E_Commerce.Shared.Services.Interfaces.Base64FileValidator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Shared.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddSingleton(services);
            services.AddTransientServices(configuration);
            services.AddScopedServices(configuration);
            services.AddSingletonServices(configuration);
            return services;
        }

        private static IServiceCollection AddTransientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILoggingTool, LoggingTool>();
            services.AddTransient<IBase64AnyFileValidator, Base64AnyFileValidator>();
            services.AddTransient<IBase64ImageFileValidator, Base64ImageFileValidator>();
            return services;
        }
        private static IServiceCollection AddScopedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
        private static IServiceCollection AddSingletonServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}