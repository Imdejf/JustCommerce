using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Application.IntegrationTests
{
    public class DependencyContainer
    {
        private IServiceCollection _services;
        public DependencyContainer()
        {
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.test.json", true, true)
                                    .Build();

            var startup = new Startup(configuration, true);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            _services = services;
        }

        public T GetService<T>()
        {
            return _services.BuildServiceProvider().GetRequiredService<T>();
        }
    }
}
