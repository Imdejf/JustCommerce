namespace Watermark.IntegrationTests.WatermarkConvertor
{
    public class WatermarkConvertorTests
    {
    //    IConverterBuilder _converter;
    //    public WatermarkConvertorTests()
    //    {
    //        _converter = new ConverterBuilder();
    //    }
    //    [Fact]
    //    public void Returns_WavFile_After_Converted_Mp3_To_Wav()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileMp3 = File.ReadAllBytes($@"{pathToFile}\test.mp3");
    //        var mp3 = ToolsToTest.GetExtension(fileMp3);

    //        Assert.Equal(mp3, WatermarkFileType.MP3);

    //        var fileWav = _converter.OnAudioFile(fileMp3)
    //                              .AsWav()
    //                              .AsByteArray();
    //        var wav = ToolsToTest.GetExtension(fileWav);

    //        Assert.Equal(wav, WatermarkFileType.WAV);
    //    }

    //    [Fact]
    //    public void Returns_Mp3File_After_Converted_Wav_To_Mp3()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileWav = File.ReadAllBytes($@"{pathToFile}\test.wav");
    //        var wav = ToolsToTest.GetExtension(fileWav);

    //        Assert.Equal(wav, WatermarkFileType.WAV);

    //        var fileMp3 = _converter.OnAudioFile(fileWav)
    //                              .AsMp3()
    //                              .AsByteArray();
    //        var mp3 = ToolsToTest.GetExtension(fileMp3);

    //        Assert.Equal(mp3, WatermarkFileType.MP3);
    //    }

    //    [Fact]
    //    public void Returns_File_As_Base64()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileWav = File.ReadAllBytes($@"{pathToFile}\test.wav");

    //        var wav = ToolsToTest.GetExtension(fileWav);

    //        Assert.Equal(wav, WatermarkFileType.WAV);

    //        var fileMp3 = _converter.OnAudioFile(fileWav)
    //                              .AsMp3()
    //                              .AsBase64File();
    //        var mp3 = ToolsToTest.GetExtension(Convert.FromBase64String(fileMp3));

    //        Assert.Equal(mp3, WatermarkFileType.MP3);
    //    }

    //    [Fact]
    //    public void Returns_File_As_Stream()
    //    {
    //        byte[] fileWav = File.ReadAllBytes(@"D:/Watermark/test.wav");
    //        var wav = ToolsToTest.GetExtension(fileWav);

    //        Assert.Equal(wav, WatermarkFileType.WAV);

    //        var fileMp3 = _converter.OnAudioFile(fileWav)
    //                              .AsMp3()
    //                              .AsStream();

    //        MemoryStream ms = (MemoryStream)fileMp3;
    //        byte[] fileBytes = ms.ToArray();

    //        var mp3 = ToolsToTest.GetExtension(fileBytes);

    //        Assert.Equal(mp3, WatermarkFileType.MP3);
    //    }

    //    [Fact]
    //    public void Returns_Mp3File_After_Converted_Mp4_To_Mp3()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileMp4 = File.ReadAllBytes($@"{pathToFile}\test.mp4");

    //        var mp4 = ToolsToTest.GetExtension(fileMp4);

    //        Assert.Equal(mp4, WatermarkFileType.MP4);

    //        var fileMp3 = _converter.OnVideoFile(fileMp4)
    //                                .AsMp3()
    //                                .GetAudio()
    //                                .AsByteArray();
    //        var mp3 = ToolsToTest.GetExtension(fileMp3);

    //        Assert.Equal(mp3, WatermarkFileType.MP3);
    //    }
    //    [Fact]
    //    public void Returns_WavFile_After_Converted_Mp4_To_Wav()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileMp4 = File.ReadAllBytes($@"{pathToFile}\test.mp4");

    //        var mp4 = ToolsToTest.GetExtension(fileMp4);

    //    //    Assert.Equal(mp4, WatermarkFileType.MP4);

    //        var fileWav = _converter.OnVideoFile(fileMp4)
    //                            .AsWav()
    //                            .GetAudio()
    //                            .AsByteArray();
    //        var wav = ToolsToTest.GetExtension(fileWav);
    //        Assert.Equal(wav, WatermarkFileType.WAV);
    //    }

    //    [Fact]
    //    public void Delete_File_From_Path_After_Change_File()
    //    {

    //        var inputDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0];
    //        inputDirectory += $@"Watermark\\Watermark\\FFmpeg\\input.mp4";

    //        var outputDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0];
    //        outputDirectory += $@"Watermark\\Watermark\\FFmpeg\\input.mp4";

    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileWav = File.ReadAllBytes($@"{pathToFile}\test.wav");
    //        var soundWav = File.ReadAllBytes($@"{pathToFile}\test.docx");

    //        var file = _converter.OnVideoFile(fileWav)
    //                             .AsMp4()
    //                             .ChangeAudio(soundWav)
    //                             .AsByteArray();


    //    //    var outputDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0];
    //    //    outputDirectory += $@"Watermark\\Watermark\\FFmpeg\\input.mp4";

    //    //    var pathToFile = ToolsToTest.PathToTestFile();
    //    //    var fileWav = File.ReadAllBytes($@"{pathToFile}\test.wav");
    //    //    var soundWav = File.ReadAllBytes($@"{pathToFile}\test.docx");

    //    //    var file = _converter.OnVideoFile(fileWav)
    //    //                         .AsMp4()
    //    //                         .ChangeAudio(soundWav)
    //    //                         .AsByteArray();

    //        Assert.NotNull(file);
    //        Assert.False(File.Exists(inputDirectory));
    //        Assert.False(File.Exists(outputDirectory));
    //    }

    //    [Fact]
    //    public void Add_Picture_To_Video()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileMp4 = File.ReadAllBytes($@"{pathToFile}\test.mp4");
    //        var pictureWatermark = File.ReadAllBytes($@"{pathToFile}\test.jpg");


    //        var fileBytes = _converter.OnVideoFile(fileMp4)
    //                             .AsMp4()
    //                             .AddPicture(pictureWatermark)
    //                             .AsByteArray();

    //        var fileExtension = ToolsToTest.GetExtension(fileBytes);

    //        Assert.Equal(WatermarkFileType.MP4, fileExtension);
    //    }

    //    [Fact]
    //    public void Return_File_As_Flac()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var flac = File.ReadAllBytes($@"{pathToFile}\test.flac");
    //        var fileBytes = _converter.OnAudioFile(flac)
    //                                  .AsFlac()
    //                                  .AsByteArray();

    //        var fileExtension = ToolsToTest.GetExtension(fileBytes);

    //        Assert.Equal(WatermarkFileType.FLAC, fileExtension);

    //    }

    //    [Fact]
    //    public void Throw_Exception_If_File_Format_Is_Bad()
    //    {
    //        var pathToFile = ToolsToTest.PathToTestFile();
    //        var fileMp4 = File.ReadAllBytes($@"{pathToFile}\test.jpg");
    //        var pictureWatermark = File.ReadAllBytes($@"{pathToFile}\test.jpg");

    //        Assert.Throws<NotImplementedException>(() => _converter.OnVideoFile(fileMp4)
    //                                                             .AsMp4()
    //                                                             .AddPicture(pictureWatermark)
    //                                                             .AsByteArray());

    //    //}
    }
}
