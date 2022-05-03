using System;
using System.IO;
using Watermark.Enums;

namespace Watermark.IntegrationTests.Tools
{
    public static class ToolsToTest
    {
        public static WatermarkFileType GetExtension(byte[] array)
        {
            string base64File = Convert.ToBase64String(array);

            switch (base64File.Substring(0, 5).ToUpper())
            {
                case "IVBOR":
                    return WatermarkFileType.PNG;
                case "/9J/4":
                    return WatermarkFileType.JPG;
                case "AAAAF":
                case "AAAAG":
                case "AAAAI":
                    return WatermarkFileType.MP4;
                case "JVBER":
                    return WatermarkFileType.PDF;
                case "UKLGR":
                    return WatermarkFileType.WAV;
                case "UESDB":
                    return WatermarkFileType.DOCX;
                case "SUQZB":
                case "//USA":
                    return WatermarkFileType.MP3;
                case "ZKXHQ":
                    return WatermarkFileType.FLAC;
                default:
                    throw new NotImplementedException("Send extension not supported");
            }
        }

        public static string PathToTestFile()
        {
            var path = Directory.GetCurrentDirectory().Split("bin")[0];
            path += @"\Resources";

            return path;
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            MemoryStream ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
