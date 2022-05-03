using Microsoft.Extensions.Options;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using Watermark.Configs;
using Watermark.Enums;
using Watermark.Implementations.Tools;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.Handler.WatermarkWrapper
{
    /// <summary>
    /// Default implementation class of <see cref="IWatermarkHandler"/> for .jpg file
    /// </summary>
    internal sealed class ImageJpg : WatermarkGenerator<WatermarkImageConfig>, IWatermarkHandler
    {
        public WatermarkFileType Type { get; set; } = WatermarkFileType.JPG;
                
        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="imageHelper"><see cref="IWatermarkImageHelper"/> added in DI container</param>
        /// <param name="config"><see cref="WatermarkImageConfig"/> configured in DI container</param>
        public ImageJpg(IOptions<WatermarkImageConfig> config) : base(config.Value)
        {
            _FuncsMap = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>
            {
                { WatermarkOperation.AddPicture, addPicture },
                { WatermarkOperation.AddText, addText },
            };
        }
        
        private MemoryStream addPicture(byte[] byteImage)
        {
            using (var memory = new MemoryStream(byteImage))
            using (var image = Image.Load(memory, out IImageFormat format))
            using (var watermarkImage = Image.Load(_Config.WatermarkImage))
            {
                (int x, int y) = WatermarkHelper.GetPositionForImage(image.Width, image.Height, watermarkImage.Width, watermarkImage.Height, _Config.WatermarkPosition, _Config.Margin);
                image.Mutate(c => c.DrawImage(watermarkImage, new Point(x, y), _Config.Opacity));

                using (var saveMemory = new MemoryStream())
                {
                    image.Save(saveMemory, format);
                    return saveMemory;
                }
            }
        }

        private MemoryStream addText(byte[] byteImage)
        {
            FontCollection fonts = new FontCollection();
            string fontPath = Directory.GetCurrentDirectory().Split("src")[0] + @"\\Modules\\Watermark\\Watermark\\Resources\\Fonts\\font.ttf";
            fonts.Add(fontPath);

            fonts.TryGet("Roboto Black", out FontFamily family);
            Font font = family.CreateFont(_Config.FontSize);

            using (var memory = new MemoryStream(byteImage))
            using (var image = Image.Load(memory, out IImageFormat format))
            {
                (float x, float y) = WatermarkHelper.GetPositionForText(image.Width, image.Height, _Config.WatermarkPosition, _Config.FontSize, _Config.Margin);
                image.Mutate(c => c.DrawText(_Config.WatermarkText, font, Color.ParseHex(_Config.WatermarkTextColorHex), new PointF(x, y)));

                using (var saveMemory = new MemoryStream())
                {
                    image.Save(saveMemory, format);
                    return saveMemory;
                }
            }
        }
    }
}
