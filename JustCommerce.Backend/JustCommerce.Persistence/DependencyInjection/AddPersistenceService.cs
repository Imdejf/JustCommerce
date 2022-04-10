using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures;
using JustCommerce.Persistence.DataAccess;
using JustCommerce.Persistence.Implementations.CommonRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Persistence.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            //Transient
            services.AddTransient<IUserManager, UserManager>();

            return services;
        }
    }
}
