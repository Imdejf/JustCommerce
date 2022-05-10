using DataSharp.EmailSender.DependencyInjection;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Infrastructure.Implementations;
using JustCommerce.Infrastructure.Implementations.File;
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
            services.AddTransient<IWatermarkManager, WatermarkManager>();
            services.AddTransient<IPdfBuilder, PdfBuilder>();

            services.AddEmailTemplateProvider(c =>
            {
                c.AddTemplate("EmailConfirmation", a =>
                    a.WithHtmlBodyFromFile("EmailTemplates/EmailConfirmation.html")
                     .AddReplacementKey("[EMAILADDRESS]")
                     .AddReplacementKey("[URL]")
                );

                c.AddTemplate("Offer", a =>
                    a.WithHtmlBodyFromFile("EmailTemplates/Offer.html")
                );
            });
            return services;
        }
    }
}
