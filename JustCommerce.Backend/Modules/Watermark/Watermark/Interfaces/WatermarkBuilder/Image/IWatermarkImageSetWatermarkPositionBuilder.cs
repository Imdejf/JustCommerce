using Watermark.Enums;

namespace Watermark.Interfaces.WatermarkBuilder.Image
{
    public interface IWatermarkImageSetWatermarkPositionBuilder
    {
        IWatermarkImageSetOpacityBuilder SetWatermarkPosition(WatermarkPosition position = WatermarkPosition.Center);
    }
}
