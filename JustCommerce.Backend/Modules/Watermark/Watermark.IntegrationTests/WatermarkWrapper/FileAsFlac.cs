using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Watermark.DependencyInjection;
using Watermark.Enums;
using Watermark.IntegrationTests.Tools;
using Watermark.Interfaces.WatermarkGenerator;
using Xunit;

namespace Watermark.IntegrationTests.WatermarkWrapper
{
    public class FileAsFlac
    {
        ServiceCollection _services;
        public FileAsFlac()
        {
            _services = new ServiceCollection();
        }
        public void AddConfig()
        {
            _services.AddConfigForSoundWatermark(new Watermark.Configs.WatermarkSoundConfig());
            _services.AddConfigForVideoWatermark(new Watermark.Configs.WatermarkVideoConfig());
            _services.AddConfigForImageWatermark(new Watermark.Configs.WatermarkImageConfig() { Operation = Watermark.Enums.WatermarkOperation.AddPicture });
            _services.AddConfigForFileWatermark(new Watermark.Configs.WatermarkTextFileConfig());
            _services.AddWatermark();
        }

        [Fact]
        public async void Returns_Async_File_As_Base64_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.flac");
            
            var base64 = await wrapper.OnFile(bytes)
                                      .AsBase64FileAsync();

            Assert.Equal(base64.GetType(), typeof(string));

            var flac = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.FLAC, flac);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.flac");

            var base64 = wrapper.OnFile(bytes)
                                .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var flac = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.FLAC, flac);
        }
    }
}
