namespace Watermark.Interfaces.WatermarkBuilder.Image
{
    public interface IWatermarkImageSetOpacityBuilder
    {
        IWatermarkImageSetMarginBuilder SetOpacity(float opacity = 0.5f);
    }
}
