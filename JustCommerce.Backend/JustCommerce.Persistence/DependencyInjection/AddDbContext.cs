using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Persistence.DataAccess;
using JustCommerce.Shared.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Persistence.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddJustCommerceDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JustCommerceDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                    options.LogTo(System.Console.WriteLine);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                }
            );
            services.AddTrackingDisposeBehaviour<JustCommerceDbContext>();
            services.AddScoped<IUnitOfWorkAdministration, JustCommerceDbContext>();
            services.AddScoped<IUnitOfWorkManagmenet, JustCommerceDbContext>();

            return services;
        }

        public static IServiceCollection AddInMemoryAuthDbContext(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<JustCommerceDbContext>(
                options =>
                {
                    options.UseInMemoryDatabase(databaseName);
                    options.LogTo(System.Console.WriteLine);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                }
            );
            services.AddTrackingDisposeBehaviour<JustCommerceDbContext>();
            services.AddScoped<IUnitOfWorkAdministration, JustCommerceDbContext>();
            services.AddScoped<IUnitOfWorkManagmenet, JustCommerceDbContext>();

            return services;
        }
    }
}
