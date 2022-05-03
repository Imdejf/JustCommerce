using System;
using System.IO;
using Watermark.Enums;

namespace Watermark.Implementations.Tools
{
    internal static class WatermarkHelper
    {
        public static (float x, float y) GetPositionForText(float currentX, float currentY, WatermarkPosition position, float fontSize = 20, float margin = 0)
        {
            float x = 0;
            float y = 0;
            switch (position)
            {
                case WatermarkPosition.Center:
                    x = (currentX - (fontSize * 2.5f)) / 2;
                    y = (currentY - fontSize) / 2;
                    return (x, y);
                case WatermarkPosition.TopRight:
                    x = (currentX - (fontSize * 2.5f)) - margin;
                    y = margin;
                    return (x, y);
                case WatermarkPosition.TopLeft:
                    x = margin;
                    y = margin;
                    return (x, y);
                case WatermarkPosition.BottomRight:
                    x = (currentX - (fontSize * 2.5f)) - margin;
                    y = (currentY - fontSize) - margin;
                    return (x, y);
                case WatermarkPosition.BottomLeft:
                    x = margin;
                    y = (currentY - fontSize) - margin;
                    return (x, y);
                default:
                    throw new InvalidDataException("Send watermark position not in enum");
            }
        }

        public static (int x, int y) GetPositionForImage(
        int currentImageX,
        int currentImageY,
        int currentWatermarkX,
        int currentWatermarkY,
        WatermarkPosition position,
        int margin = 0)
        {
            int x = 0;
            int y = 0;
            switch (position)
            {
                case WatermarkPosition.Center:
                    x = ((currentImageX / 2) + margin) - ((currentWatermarkX / 2) + margin);
                    y = (currentImageY / 2) - (currentWatermarkY / 2);
                    return (x, y);
                case WatermarkPosition.TopRight:
                    x = (currentImageX - currentWatermarkX) - margin;
                    y = margin;
                    return (x, y);
                case WatermarkPosition.TopLeft:
                    x = margin;
                    y = margin;
                    return (x, y);
                case WatermarkPosition.BottomRight:
                    x = (currentImageX - currentWatermarkX) - margin;
                    y = (currentImageY - currentWatermarkY) - margin;
                    return (x, y);
                case WatermarkPosition.BottomLeft:
                    x = margin;
                    y = (currentImageY - currentWatermarkY) - margin;
                    return (x, y);
                default:
                    throw new Exception();
            }
        }
        public static WatermarkFileType GetTypeOfFile(byte[]? array)
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
                    return WatermarkFileType.MP3;
                case "ZKXHQ":
                    return WatermarkFileType.FLAC;
                default:
                    throw new NotImplementedException("Send extension not supported");
            }
        }
        public static int GetRoundTime(int totalTimeSeconds)
        {
            return (totalTimeSeconds + (10 - (totalTimeSeconds % 10)));
        }
    }
}
