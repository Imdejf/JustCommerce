using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Application
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
