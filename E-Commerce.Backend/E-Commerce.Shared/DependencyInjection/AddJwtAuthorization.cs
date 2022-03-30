using E_Commerce.Shared.Configurations;
using E_Commerce.Shared.Services.Implementations.JwtService;
using E_Commerce.Shared.Services.Interfaces.JwtService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, JwtServiceConfig jwtServiceConfig)
        {
            services.AddTransient<IJwtDecoder, JwtDecoder>();
            services.AddTransient<IJwtValidator, JwtValidator>();
            services.Configure<JwtServiceConfig>(c =>
            {
                c.Issuer = jwtServiceConfig.Issuer;
                c.ReferralId = jwtServiceConfig.ReferralId;
                c.ReferralUrl = jwtServiceConfig.ReferralUrl;
                c.RsaPrivateKey = jwtServiceConfig.RsaPrivateKey;
                c.RsaPublicKey = jwtServiceConfig.RsaPublicKey;
                c.TokenLifetimeInMinutes = jwtServiceConfig.TokenLifetimeInMinutes;
                c.Audience = jwtServiceConfig.Audience;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = jwtServiceConfig.AsTokenValidationParameters();
            });

            services.AddAuthorization(options =>
            {
                options.InvokeHandlersAfterFailure = true;
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            return services;
        }
    }

    public static partial class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseJwtAuthorization(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
