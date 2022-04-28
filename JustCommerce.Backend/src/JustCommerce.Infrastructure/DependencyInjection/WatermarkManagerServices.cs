using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Watermark.DependencyInjection;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWatermarkManager(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddWatermark();

            services.AddConfigForImageWatermark(new Watermark.Configs.WatermarkImageConfig()
            {
                Operation = Watermark.Enums.WatermarkOperation.AddPicture | Watermark.Enums.WatermarkOperation.AddText
            });

            services.AddConfigForFileWatermark(new Watermark.Configs.WatermarkTextFileConfig()
            {
                Operation = Watermark.Enums.WatermarkOperation.AddPicture | Watermark.Enums.WatermarkOperation.AddText
            });

            return services;
        }
    }
}
