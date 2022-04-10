using DataSharp.EmailSender.DependencyInjection;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Infrastructure.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailLinksConfig>(configuration.GetSection("MailLinks"));
            services.AddTransient<IMailSender, MailSender>();
            services.AddTransient<IJwtGenerator, JwtGenerator>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();

            services.AddEmailTemplateProvider(c =>
            {
                c.AddTemplate("EmailConfirmation", a =>
                    a.WithHtmlBodyFromFile("EmailTemplates/EmailConfirmation.html")
                     .AddReplacementKey("[EMAILADDRESS]")
                     .AddReplacementKey("[URL]")
                );
            });
            return services;
        }
    }
}
