using Microsoft.Extensions.DependencyInjection;
using Watermark.DependencyInjection;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWatermarkManager(this IServiceCollection services)
        {
            services.AddWatermark();

            services.AddConfigForImageWatermark(new Watermark.Configs.WatermarkImageConfig()
            {
                
            });

            return services;
        }
    }
}
