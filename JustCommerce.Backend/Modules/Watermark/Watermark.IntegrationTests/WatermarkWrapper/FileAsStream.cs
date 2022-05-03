using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Watermark.DependencyInjection;
using Watermark.Enums;
using Watermark.IntegrationTests.Tools;
using Watermark.Interfaces.WatermarkGenerator;
using Xunit;

namespace Watermark.IntegrationTests.WatermarkWrapper
{
    public class FileAsStream
    {

        ServiceCollection _services;
        public FileAsStream()
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
        public void Send_File_As_Stream_And_Return_Byte_Array()
        {
            AddConfig();

            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var docxFile = File.ReadAllBytes($@"{pathToFile}\test.docx");
            
            var stream = new MemoryStream(docxFile);

            var byteArray = wrapper.OnFile(stream)
                                   .AsByteArray();

            Assert.Equal(byteArray.GetType(), typeof(byte[]));
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Jpg_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.jpg");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));

            var jpg = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.JPG, jpg);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Png_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.png");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var png = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.PNG, png);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Pdf_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.pdf");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var pdf = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.PDF, pdf);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Wav_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.wav");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var wav = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.WAV, wav);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Docx_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.docx");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var docx = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.DOCX, docx);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Mp3_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp3"); 
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var mp3 = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.MP3, mp3);
        }

        [Fact]
        public void Returns_File_As_Stream_If_Send_File_With_Mp4_Extension()
        {
            AddConfig();
            var provider = _services.BuildServiceProvider();
            var wrapper = provider.GetRequiredService<IWatermarkGenerator>();

            var pathToFile = ToolsToTest.PathToTestFile();
            var bytes = File.ReadAllBytes($@"{pathToFile}\test.mp4");
            
            var stream = wrapper.OnFile(bytes)
                                   .AsStream();

            Assert.Equal(stream.GetType(), typeof(MemoryStream));


            var mp4 = ToolsToTest.GetExtension(ToolsToTest.StreamToByteArray(stream));

            Assert.Equal(WatermarkFileType.MP4, mp4);
        }
    }
}
