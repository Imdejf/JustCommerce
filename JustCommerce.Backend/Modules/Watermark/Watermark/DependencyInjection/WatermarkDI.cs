using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Watermark.Configs;
using Watermark.Implementations.Converter.ConverterBuilder;
using Watermark.Implementations.Tools;
using Watermark.Implementations.WatermarkConfigBuilder.File;
using Watermark.Implementations.WatermarkConfigBuilder.Image;
using Watermark.Implementations.WatermarkConfigBuilder.Sound;
using Watermark.Implementations.WatermarkConfigBuilder.Video;
using Watermark.Implementations.WatermarkGenerator;
using Watermark.Interfaces.Converter.ConverterBuilder;
using Watermark.Interfaces.Tools;
using Watermark.Interfaces.WatermarkBuilder.File;
using Watermark.Interfaces.WatermarkBuilder.Image;
using Watermark.Interfaces.WatermarkBuilder.Sound;
using Watermark.Interfaces.WatermarkBuilder.Video;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.DependencyInjection
{
    public static class WatermarkDI
    {
        /// <summary>
        /// Registers <see cref="IWatermarkHandler"/> as Transient in <see cref="IServiceCollection"/> with <br/>
        /// passed handlers />.
        /// </summary>
        /// <param name="services">source</param>
        /// <returns>services</returns>
        private static IServiceCollection Scan(this IServiceCollection services)
        {
            var type = typeof(IWatermarkHandler);
            var classes = Assembly.GetExecutingAssembly().GetTypes().Where(c => type.IsAssignableFrom(c)).ToList();
            classes.Remove(type);
            foreach (var impClass in classes.ToList()) 
            {
                services.AddTransient(type, impClass);
            }
            return services;
        }

        /// <summary>
        /// Registers WatermarkHelper service
        /// Registers WatermarkImageHelper service
        /// Registers WatermarkTextFileHelper service
        /// Registers WatermarkSoundHelper service
        /// Registers ConverterBuilder service
        /// Registers WatermarkWrapper service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configBuildAction">Action used to configure EmailSender</param>
        /// <returns></returns>
        public static IServiceCollection AddWatermark(this IServiceCollection services)
        {
            #region Tools
            services.AddTransient<IWavSoundConcatenater, WavSoundConcatenater>();
            services.AddTransient<IWavSoundComparer, WavSoundComparer>();
            services.AddTransient<IWavSoundCutter, WavSoundCutter>();
            services.AddTransient<IWavSoundMixer, WavSoundMixer>();
            #endregion

            #region ConfigBuilder
            services.AddTransient<IWatermarkImageSetWatermarkBuilder, WatermarkImageConfigBuilder>();
            services.AddTransient<IWatermarkTextFileSetWatermarkBuilder, WatermarkTextFileConfigBuilder>();
            services.AddTransient<IWatermarkSoundSetWatermarkBuilder, WatermarkSoundConfigBuilder>();
            services.AddTransient<IWatermarkVideoSetWatermarkBuilder, WatermarkVideoConfigBuilder>();
            #endregion

            #region DefaultConfigs 
            services.Configure<WatermarkImageConfig>(c => new WatermarkImageConfig());
            services.Configure<WatermarkTextFileConfig>(c => new WatermarkTextFileConfig());
            services.Configure<WatermarkSoundConfig>(c => new WatermarkSoundConfig());
            services.Configure<WatermarkVideoConfig>(c => new WatermarkVideoConfig());
            #endregion

            services.Scan();
            services.AddTransient<IConverterBuilder, ConverterBuilder>();
            services.AddTransient<IWatermarkGenerator, WatermarkGenerator>();            
            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkTextFileConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for text file</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForTextFileWatermarkBuilder(this IServiceCollection services, Action<IWatermarkTextFileSetWatermarkBuilder> build)
        {
            WatermarkTextFileConfigBuilder test = new WatermarkTextFileConfigBuilder();
            build.Invoke(test);
            var config = test.Build();
            services.Configure<WatermarkTextFileConfig>(c =>
            {
                c.FontSize = config.FontSize;
                c.ImageWatermark = config.ImageWatermark;
                c.Margin = config.Margin;
                c.Opacity = config.Opacity;
                c.Operation = config.Operation;
                c.TextWatermark = config.TextWatermark;
                c.WatermarkTextColorHex = config.WatermarkTextColorHex;
            });

            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkImageConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for image</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForImageWatermarkBuilder(this IServiceCollection services, Action<IWatermarkImageSetWatermarkBuilder> build)
        {
            WatermarkImageConfigBuilder test = new WatermarkImageConfigBuilder();
            build.Invoke(test);
            var config = test.Build();

            services.Configure<WatermarkImageConfig>(c =>
            {
                c.FontSize = config.FontSize;
                c.Margin = config.Margin;
                c.Opacity = config.Opacity;
                c.Operation = config.Operation;
                c.WatermarkImage = config.WatermarkImage;
                c.WatermarkPosition = config.WatermarkPosition;
                c.WatermarkText = config.WatermarkText;
                c.WatermarkTextColorHex = config.WatermarkTextColorHex;

            });
            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkSoundConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for sound</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForSoundWatermarkBuilder(this IServiceCollection services, Action<IWatermarkSoundSetWatermarkBuilder> build)
        {
            WatermarkSoundConfigBuilder test = new WatermarkSoundConfigBuilder();
            build.Invoke(test);
            var config = test.Build();
            services.Configure<WatermarkSoundConfig>(c =>
            {
                c.IntervalBetweenSound = config.IntervalBetweenSound;
                c.Operation = config.Operation;
                c.Sound = config.Sound;

            });

            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkVideoConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for video</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForVideoWatermarkBuilder(this IServiceCollection services, Action<IWatermarkVideoSetWatermarkBuilder> build)
        {
            WatermarkVideoConfigBuilder test = new WatermarkVideoConfigBuilder();
            build.Invoke(test);
            var config = test.Build();
            services.Configure<WatermarkVideoConfig>(c =>
            {
                c.IntervalBetweenSound = config.IntervalBetweenSound;
                c.Operation = config.Operation;
                c.Sound = config.Sound;
            });

            return services;
        }


        /// <summary>
        /// Passed <see cref="WatermarkImageConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for image</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForImageWatermark(this IServiceCollection services, WatermarkImageConfig config) 
        {
            services.Configure<WatermarkImageConfig>(c => 
            {
                c.FontSize = config.FontSize;
                c.Margin = config.Margin;
                c.Opacity = config.Opacity;
                c.Operation = config.Operation;
                c.WatermarkImage = config.WatermarkImage;
                c.WatermarkPosition = config.WatermarkPosition;
                c.WatermarkText = config.WatermarkText;
                c.WatermarkTextColorHex = config.WatermarkTextColorHex;

            });            
            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkTextFileConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for file</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForFileWatermark(this IServiceCollection services, WatermarkTextFileConfig config) 
        {            
            services.Configure<WatermarkTextFileConfig>(c => 
            {
                c.FontSize = config.FontSize;
                c.ImageWatermark = config.ImageWatermark;
                c.Margin = config.Margin;
                c.Opacity = config.Opacity;
                c.Operation = config.Operation;
                c.TextWatermark = config.TextWatermark;
                c.WatermarkTextColorHex = config.WatermarkTextColorHex;               
            });
            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkSoundConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for sound file</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForSoundWatermark(this IServiceCollection services, WatermarkSoundConfig config) 
        {
            services.Configure<WatermarkSoundConfig>(c => 
            {
                c.IntervalBetweenSound = config.IntervalBetweenSound;
                c.Operation = config.Operation;
                c.Sound = config.Sound;

            });
            return services;
        }

        /// <summary>
        /// Passed <see cref="WatermarkVideoConfig"/> action.
        /// </summary>
        /// <param name="services">source</param>
        /// <param name="config">watermark configuration for video file</param>
        /// <returns>services</returns>
        public static IServiceCollection AddConfigForVideoWatermark(this IServiceCollection services, WatermarkVideoConfig config) 
        {
            services.Configure<WatermarkVideoConfig>(c => 
            {
                c.IntervalBetweenSound = config.IntervalBetweenSound;
                c.Operation = config.Operation;
                c.Sound = config.Sound;
            });
            return services;
        }
            
    }
}
