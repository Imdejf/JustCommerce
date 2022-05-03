using System;
using System.IO;
using Watermark.Interfaces.Converter.ConverterBuilder;

namespace Watermark.Implementations.Converter.ConverterBuilder
{
    internal sealed class ConverterBuilder :
        IConverterBuilder,
        IConverterSetAudioExtensionBuilder,
        IConverterSetVideoExtensionBuilder,
        IConverterSetVideoOperationBuilder,
        IConverterSetTypeBuilder
    {
        private byte[]? _inputFile;
        private byte[]? _result;
        private string? _inputExtension;
        private string? _outputExtension;        

        public IConverterSetAudioExtensionBuilder OnAudioFile(byte[] inputFile)
        {
            _inputExtension = getAudioExtension(inputFile);
            var path = getInputPath();            
            File.WriteAllBytes(path, inputFile);

            return this;
        }
        public IConverterSetVideoExtensionBuilder OnVideoFile(byte[] inputFile)
        {
            _inputExtension = getVideoExtension(inputFile);
            var path = getInputPath();
            File.WriteAllBytes(path, inputFile);

            return this;
        }

        public IConverterSetTypeBuilder AsFlac()
        {
            _outputExtension = ".flac";
            _result = convertAudioFile(_inputExtension, _outputExtension);
            return this;
        }
        public IConverterSetTypeBuilder AsWav()
        {
            _outputExtension = ".wav";
            _result = convertAudioFile(_inputExtension, _outputExtension);
            return this;
        }
        public IConverterSetTypeBuilder AsMp3()
        {
            _outputExtension = ".mp3";
            _result = convertAudioFile(_inputExtension, _outputExtension);
            return this;
        }

        IConverterSetVideoOperationBuilder IConverterSetVideoExtensionBuilder.AsMp4()
        {
            _outputExtension = ".mp4";
            return this;
        }
        IConverterSetVideoOperationBuilder IConverterSetVideoExtensionBuilder.AsWav()
        {
            _outputExtension = ".wav";
            return this;
        }
        IConverterSetVideoOperationBuilder IConverterSetVideoExtensionBuilder.AsMp3()
        {        
            _outputExtension = ".mp3";
            return this;
        }

        public IConverterSetTypeBuilder GetAudio()
        {
            _result = convertVideoFile(_inputExtension, _outputExtension);
            return this;
        }
        public IConverterSetTypeBuilder ChangeAudio(byte[] newAudio)
        {            
            var path = Directory.GetCurrentDirectory().Split("Watermark")[0] + @"\Watermark\Watermark\FFmpeg\changedAudio.mp3";
            File.WriteAllBytes(path, newAudio);
            _result = changeSoundInVideo(_inputExtension, _outputExtension);
            File.Delete(path);
            return this;
        }
        public IConverterSetTypeBuilder AddPicture(byte[] pictureWatermark)
        {
            var pictureExtension = getPictureExtension(pictureWatermark);
            var path = Directory.GetCurrentDirectory().Split("Watermark")[0] + $@"\Watermark\Watermark\FFmpeg\pictureWatermark{pictureExtension}";

            File.WriteAllBytes(path, pictureWatermark);
            _result = addPictureToVideo(_inputExtension, _outputExtension, pictureExtension);
            File.Delete(path);
            return this;

        }
        public string AsBase64File()
        {
            removeFiles();
            return Convert.ToBase64String(_result);
        }
        public byte[] AsByteArray()
        {
            removeFiles();
            return _result;
        }
        public Stream AsStream()
        {
            removeFiles();
            return new MemoryStream(_result);
        }
        private string getPictureExtension(byte[] picture) 
        {
            string base64File = Convert.ToBase64String(picture);
            switch (base64File[..5].ToUpper())
            {
                case "IVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpg";
                default:
                    throw new NotImplementedException("Send extension not supported");
            }
        }

        private string getAudioExtension(byte[] inputFile)
        {
            string base64File = Convert.ToBase64String(inputFile);
            switch (base64File[..5].ToUpper())
            {
                case "SUQZA":
                case "SUQZB":
                case "//USA":
                    return ".mp3";
                case "UKLGR":
                    return ".wav";
                case "ZKXHQ":
                    return ".flac";
                default:
                    throw new NotImplementedException("Send extension not supported");
            }
        }
        private string getVideoExtension(byte[] inputFile)
        {
            string base64File = Convert.ToBase64String(inputFile);

            switch (base64File[..5].ToUpper())
            {
                case "AAAAF":
                case "AAAAG":
                case "AAAAI":
                    return ".mp4";
                default:
                    throw new NotImplementedException("Send extension not supported");
            }
        }

        private byte[] convertAudioFile(string inputExt, string outExt)
        {
            string argument = $"-y -i input{inputExt} output{outExt}";
            new FFmpegConverter(argument)
                .Start();
            var path = getOutputPath();
            return File.ReadAllBytes(path);
        }
        private byte[] convertVideoFile(string inputExt, string outExt)
        {
            string argument = $"-y -i input{inputExt} -b:a 192K -vn output{outExt}";            
            new FFmpegConverter(argument)
                .Start();
            var path = getOutputPath();
            return File.ReadAllBytes(path);
        }
        private byte[] changeSoundInVideo(string inputExt, string outExt)
        {            
            string argument = $"-y -i input{inputExt} -i changedAudio.mp3 -c:v copy -map 0:v:0 -map 1:a:0 output{outExt}";
            new FFmpegConverter(argument)
                .Start();
            var path = getOutputPath();
            return File.ReadAllBytes(path);
        }
        private byte[] addPictureToVideo(string inputExt, string outExt, string pictureExt) 
        {
            string argument = $"-y -i input{inputExt} -i pictureWatermark{pictureExt} -filter_complex \"[1:v]format=argb,geq=r='r(X,Y)':a = '0.5*alpha(X,Y)'[zork];[0:v][zork]overlay=(main_w-overlay_w)/2:(main_h-overlay_h)/2\" -vcodec libx264 output{outExt}";
            new FFmpegConverter(argument)
                .Start();
            var path = getOutputPath();
            return File.ReadAllBytes(path);
        }

        private string getOutputPath()
        {            
            var currentDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0];
            currentDirectory += $@"Watermark\\Watermark\\FFmpeg\\output{_outputExtension}";

            return currentDirectory;
        }
        private string getInputPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0];            
            currentDirectory += $@"Watermark\\Watermark\\FFmpeg\\input{_inputExtension}";

            return currentDirectory;
        }        
        private void removeFiles() 
        {
            var inputPath = getInputPath();
            var outputPath = getOutputPath();

            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}
