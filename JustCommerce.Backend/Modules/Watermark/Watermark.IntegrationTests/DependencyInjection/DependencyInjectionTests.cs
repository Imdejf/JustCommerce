using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using Watermark.Configs;
using Watermark.DependencyInjection;
using Watermark.IntegrationTests.Tools;
using Xunit;

namespace Watermark.IntegrationTests.DependencyInjection
{
    public class DependencyInjectionTests
    {
        private ServiceCollection _services;
        public DependencyInjectionTests()
        {
            _services = new ServiceCollection();
        }

        [Fact]
        public void Returns_ImageConfig_If_Config_Added_Successfuly()
        {
            _services.AddConfigForImageWatermark(new Configs.WatermarkImageConfig());

            _services.AddWatermark();
            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkImageConfig>>();

            Assert.NotNull(option);
        }
        [Fact]
        public void Returns_TextFileConfig_If_Config_Added_Successfuly()
        {
            _services.AddConfigForFileWatermark(new Configs.WatermarkTextFileConfig());

            _services.AddWatermark();
            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkTextFileConfig>>();

            Assert.NotNull(option);
        }
        [Fact]
        public void Returns_SoundConfig_If_Config_Added_Successfuly()
        {
            _services.AddConfigForSoundWatermark(new Configs.WatermarkSoundConfig());

            _services.AddWatermark();
            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkSoundConfig>>();

            Assert.NotNull(option);
        }
        [Fact]
        public void Returns_VideoConfig_If_Config_Added_Successfuly()
        {
            _services.AddConfigForVideoWatermark(new Configs.WatermarkVideoConfig());

            _services.AddWatermark();
            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkVideoConfig>>();

            Assert.NotNull(option);
        }
        [Fact]
        public void Returns_ImageConfig_If_ConfigBuilder_Create_Config_Successfuly()
        {
            _services.AddWatermark();

            _services.AddConfigForImageWatermarkBuilder(c => c.SetOperation(Enums.WatermarkOperation.AddText)
                                                              .SetTextWatermark("Test")
                                                              .SetWatermarkPosition(Enums.WatermarkPosition.Center)
                                                              .SetOpacity(0.5f)
                                                              .SetMargin(10)
                                                              .SetFontSize(100));

            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkImageConfig>>();
            var config = option.Value;

            Assert.Equal(config.WatermarkText, "Test");
            Assert.Equal(config.WatermarkPosition, Enums.WatermarkPosition.Center);
            Assert.Equal(config.Operation, Enums.WatermarkOperation.AddText);
            Assert.Equal(config.Margin, 10);
            Assert.Equal(config.Opacity, 0.5f);
            Assert.Equal(config.FontSize, 100);
        }

        [Fact]
        public void Returns_FileConfig_If_ConfigBuilder_Create_Config_Successfully()
        {
            _services.AddWatermark();

            _services.AddConfigForTextFileWatermarkBuilder(c => c.SetOperation(Enums.WatermarkOperation.AddText)
                                                                 .SetTextWatermark("Test")
                                                                 .SetOpacity(0.5f));


            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkTextFileConfig>>();
            var config = option.Value;

            Assert.Equal(config.TextWatermark, "Test");
            Assert.Equal(config.Operation, Enums.WatermarkOperation.AddText);
            Assert.Equal(config.Opacity, 0.5f);
        }

        [Fact]
        public void Returns_VideoConfig_If_ConfigBuilder_Create_Config_Successfully()
        {
            var pathToFile = ToolsToTest.PathToTestFile();
            var mp3File = File.ReadAllBytes($@"{pathToFile}\test.mp3");

            _services.AddWatermark();

            _services.AddConfigForVideoWatermarkBuilder(c => c.SetOperation(Enums.WatermarkOperation.AddSound)
                                                               .SetSoundWatermark(mp3File)
                                                               .SetInterval(30));

            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkVideoConfig>>();
            var config = option.Value;

            Assert.Equal(config.IntervalBetweenSound, 30);
            Assert.Equal(config.Operation, Enums.WatermarkOperation.AddSound);
            Assert.Equal(config.Sound, mp3File);
        }

        [Fact]
        public void Returns_SoundConfig_If_ConfigBuilder_Create_Config_Successfully()
        {
            var pathToFile = ToolsToTest.PathToTestFile();
            var mp3File = File.ReadAllBytes($@"{pathToFile}\test.mp3");

            _services.AddWatermark();

            _services.AddConfigForSoundWatermarkBuilder(c => c.SetOperation(Enums.WatermarkOperation.AddSound)
                                                               .SetSoundWatermark(mp3File)
                                                               .SetInterval(30));

            var serviceProvider = _services.BuildServiceProvider();
            var option = serviceProvider.GetRequiredService<IOptions<WatermarkSoundConfig>>();
            var config = option.Value;

            Assert.Equal(config.IntervalBetweenSound, 30);
            Assert.Equal(config.Operation, Enums.WatermarkOperation.AddSound);
            Assert.Equal(config.Sound, mp3File);
        }
    }
}
