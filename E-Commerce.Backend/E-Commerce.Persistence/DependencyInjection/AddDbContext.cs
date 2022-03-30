using E_Commerce.Persistence.DbContext;
using E_Commerce.Shared.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddECommerceDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ECommerceDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                    options.LogTo(System.Console.WriteLine);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                }
            );
            services.AddTrackingDisposeBehaviour<ECommerceDbContext>();
            return services;
        }

        public static IServiceCollection AddInMemoryAuthDbContext(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<ECommerceDbContext>(
                options =>
                {
                    options.UseInMemoryDatabase(databaseName);
                    options.LogTo(System.Console.WriteLine);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                }
            );
            services.AddTrackingDisposeBehaviour<ECommerceDbContext>();
            return services;
        }
    }
}
