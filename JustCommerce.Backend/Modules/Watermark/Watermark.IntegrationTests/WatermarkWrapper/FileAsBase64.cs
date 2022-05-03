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
    public class FileAsBase64
    {
        ServiceCollection _services;
        public FileAsBase64()
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
        public void Send_File_As_Base64_And_Return_Byte_Array()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var docxFile = File.ReadAllBytes($@"{pathToFile}\test.docx");

            var byteArray = wrapper.OnFile(Convert.ToBase64String(docxFile))
                                   .AsByteArray();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.png");

            var base64 = wrapper.OnFile(bytes)
                                .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var png = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.PNG, png);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Jpg_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.jpg");
            var base64 = wrapper.OnFile(bytes)
                                   .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var jpg = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.JPG, jpg);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Pdf_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.pdf");

            var base64 = wrapper.OnFile(bytes)
                                   .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var pdf = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.PDF, pdf);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Docx_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.docx");
            
            var base64 = wrapper.OnFile(bytes)
                                   .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var docx = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.DOCX, docx);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Mp3_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp3");
            var base64 = wrapper.OnFile(bytes)
                                   .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var mp3 = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.MP3, mp3);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Mp4_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp4");

            var base64 = wrapper.OnFile(bytes)
                                .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var mp4 = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.MP4, mp4);
        }

        [Fact]
        public void Returns_File_As_Base64_If_Send_File_With_Wav_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.wav");

            var base64 = wrapper.OnFile(bytes)
                                   .AsBase64File();

            Assert.Equal(base64.GetType(), typeof(string));

            var wav = ToolsToTest.GetExtension(Convert.FromBase64String(base64));

            Assert.Equal(WatermarkFileType.WAV, wav);
        }
    }
}
