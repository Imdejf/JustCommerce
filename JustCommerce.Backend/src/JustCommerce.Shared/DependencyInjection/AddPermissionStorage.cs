using E_Commerce.Shared.MediatorPipelineBehaviours;
using E_Commerce.Shared.Services.Implementations.PermissionMapper;
using E_Commerce.Shared.Services.Interfaces.Permission;
using JustCommerce.Shared.Services.Interfaces.Permission;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Shared.DependencyInjection
{
    public static class AddPermissionStorage
    {
        public static IServiceCollection AddPermissionsStorage(this IServiceCollection services)
        {
            services.AddTransient<IPermissionValidator, PermissionValidator>();
            services.AddTransient<IPermissionsMapper, PermissionsMapper>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            return services;
        }
    }
}
