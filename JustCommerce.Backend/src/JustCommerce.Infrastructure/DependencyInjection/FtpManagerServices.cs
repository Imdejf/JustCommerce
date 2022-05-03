using DataSharp.FtpFileManagement.DependencyInjection;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Infrastructure.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFtpFileManager(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            FtpFileConfig config = new FtpFileConfig();
            configurationSection.Bind(config);

            services.AddFtpFileManager(c => {
                c.AddConnection(config.Key, a =>
                     a.WithHost(config.Host)
                      .WithCredentails(config.UserId, config.Password)
                      .UsingRootCatalog(config.UsingRootCatalog)
                      .EnableSSL(config.EnableSSL)
                      .UsePassive(config.UsePassive)
                      .KeepAlive(config.KeepAlive)
                      .WaitForReadWriteOperationExecutionFor(config.WaitForRequestExecutionFor)
                      .MaximumNumberOfFilesThatCanBeRemovedAtOnce(config.MaximumNumberOfFilesThatCanBeRemovedAtOnce)
                      .WaitForRequestExecutionFor(config.WaitForRequestExecutionFor)
                      .OnDomainName(config.OnDomainName)

                );
            });
            services.AddTransient<IFtpFileManager, FtpFileManager>();
            return services;
        }
        public static IServiceCollection CreateFtpFolder(this IServiceCollection services)
        {
            DataSharp.FtpFileManagement.Interfaces.IFtpFileManager ftpFileManager = services.BuildServiceProvider().GetRequiredService<DataSharp.FtpFileManagement.Interfaces.IFtpFileManager>();
            var currentConnection = ftpFileManager.GetCurrentConnection();
            if (!ftpFileManager.DirectoryExists(currentConnection.Value.RootFolder))
            {
                ftpFileManager.CreateDirectory(currentConnection.Value.RootFolder);
            }

            return services;
        }
    }
}
