using DataSharp.EmailSender.DependencyInjection;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.CommonServices;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Common.Interfaces.Notification;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Infrastructure.Implementations;
using JustCommerce.Infrastructure.Implementations.Common;
using JustCommerce.Infrastructure.Implementations.File;
using JustCommerce.Infrastructure.Implementations.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailLinksConfig>(configuration.GetSection("MailLinks"));
            services.Configure<SmsApiConfig>(configuration.GetSection("SmsApi"));
            services.AddTransient<IMailSender, MailSender>();
            services.AddTransient<ISmsApiManager, SmsApiManager>();
            services.AddTransient<IJwtGenerator, JwtGenerator>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<IWatermarkManager, WatermarkManager>();
            services.AddTransient<IPdfBuilder, PdfBuilder>();
            services.AddTransient<INotificationHubClientWrapper, NotificationHubClientWrapper>();

            services.AddSingleton<IUserIdsManager, UserIdsManager>();
            services.AddSingleton<INotificationHubClient, NotificationHubClient>();

            services.AddEmailTemplateProvider(c => { });

            return services;
        }
    }
}
