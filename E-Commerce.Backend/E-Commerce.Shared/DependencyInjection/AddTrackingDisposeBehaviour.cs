using E_Commerce.Shared.MediatorPipelineBehaviours;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Shared.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTrackingDisposeBehaviour<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddScoped<DbContext>(c => c.GetRequiredService<TDbContext>());
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(TrackingDisposeBehaviour<>));
            return services;
        }
    }
}
