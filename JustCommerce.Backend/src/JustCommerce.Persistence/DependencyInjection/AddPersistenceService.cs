using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Common.Interfaces.Service;
using JustCommerce.Persistence.DataAccess;
using JustCommerce.Persistence.Implementations;
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
            services.AddTransient<IUserPermissionManager, UserPermissionManager>();

            return services;
        }
    }
}
