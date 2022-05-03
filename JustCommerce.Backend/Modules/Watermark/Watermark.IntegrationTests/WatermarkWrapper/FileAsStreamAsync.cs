using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Watermark.DependencyInjection;
using Watermark.Enums;
using Watermark.IntegrationTests.Tools;
using Watermark.Interfaces.WatermarkGenerator;
using Xunit;

namespace Watermark.IntegrationTests.WatermarkWrapper
{
    public class FileAsStreamAsync
    {
        ServiceCollection _services;
        public FileAsStreamAsync()
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
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Jpg_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.jpg");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var jpg = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.JPG, jpg);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.png");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var png = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.PNG, png);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Pdf_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.pdf");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var pdf = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.PDF, pdf);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Wav_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.wav");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var wav = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.WAV, wav);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Docx_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.docx");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var docx = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.DOCX, docx);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Mp3_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp3");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var mp3 = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.MP3, mp3);
        }

        [Fact]
        public async void Returns_Async_File_As_Stream_If_Send_File_With_Mp4_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp4");
            
            var stream = await wrapper.OnFile(bytes)
                                      .AsStreamAsync();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var mp4 = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.MP4, mp4);
        }
    }
}
