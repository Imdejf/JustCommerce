using System.IO;
using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Interfaces.WatermarkBuilder.Image
{
    public interface IWatermarkImageSetWatermarkBuilder : IAbstractWatermarkConfigBuilder<IWatermarkImageSetWatermarkBuilder>
    {
        IWatermarkImageSetWatermarkPositionBuilder SetTextWatermark(string watermarkText = "DataSharp");
        IWatermarkImageSetWatermarkPositionBuilder SetPictureWatermark(byte[] watermarkImage);
    }
}
