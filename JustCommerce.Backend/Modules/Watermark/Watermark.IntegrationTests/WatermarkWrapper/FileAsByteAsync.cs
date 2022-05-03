using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Watermark.DependencyInjection;
using Watermark.Enums;
using Watermark.IntegrationTests.Tools;
using Watermark.Interfaces.WatermarkGenerator;
using Xunit;

namespace Watermark.IntegrationTests.WatermarkWrapper
{
    public class FileAsByteAsync
    {
        ServiceCollection _services;
        public FileAsByteAsync()
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
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_Docx_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var test = Directory.GetCurrentDirectory();

            var pathToFile = ToolsToTest.PathToTestFile();
            var docxFile = File.ReadAllBytes($@"{pathToFile}\test.docx");

            var byteArray = await wrapper.OnFile(docxFile)
                                   .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));

            var docx = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.DOCX, docx);
        }

        [Fact]
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_Pdf_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.pdf");
            
            var byteArray = await wrapper.OnFile(bytes)
                                         .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));

            var pdf = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.PDF, pdf);
        }

        [Fact]
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.png");
            
            var byteArray = await wrapper.OnFile(bytes)
                                         .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));

            var png = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.PNG, png);
        }

        [Fact]
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_Mp4_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp4");
            
            var byteArray = await wrapper.OnFile(bytes)
                                         .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));

            var mp4 = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.MP4, mp4);
        }

        [Fact]
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_WAV_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.wav");
            
            var byteArray = await wrapper.OnFile(bytes)
                                         .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));


            var wav = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.WAV, wav);
        }

        [Fact]
        public async void Returns_Async_File_As_Byte_Array_If_Send_File_With_Mp3_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp3");

            var byteArray = await wrapper.OnFile(bytes)
                                         .AsByteArrayAsync();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));

            var mp3 = ToolsToTest.GetExtension(byteArray);

            Assert.Equal(WatermarkFileType.MP3, mp3);
        }
    }
}
