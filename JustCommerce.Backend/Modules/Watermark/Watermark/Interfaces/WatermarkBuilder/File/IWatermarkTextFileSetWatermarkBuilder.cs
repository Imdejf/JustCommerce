using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Interfaces.WatermarkBuilder.File
{
    public interface IWatermarkTextFileSetWatermarkBuilder : IAbstractWatermarkConfigBuilder<IWatermarkTextFileSetWatermarkBuilder>
    {
        IWatermarkTextFileSetOpacityBuilder SetTextWatermark(string textWatermark);
        IWatermarkTextFileSetOpacityBuilder SetPictureWatermark(byte[] imageWatermark);
    }
}
