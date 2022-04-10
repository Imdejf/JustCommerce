using JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures;
using JustCommerce.Persistence.Implementations.CommonRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Persistence.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserManager, UserManager>();

            return services;
        }
    }
}
