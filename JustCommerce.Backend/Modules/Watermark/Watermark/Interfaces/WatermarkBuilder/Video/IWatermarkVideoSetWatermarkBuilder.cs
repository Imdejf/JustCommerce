using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Interfaces.WatermarkBuilder.Video
{
    public interface IWatermarkVideoSetWatermarkBuilder : IAbstractWatermarkConfigBuilder<IWatermarkVideoSetWatermarkBuilder>
    {
        IWatermarkVideoSetIntervalBuilder SetSoundWatermark(byte[] soundFile);
        IWatermarkVideoSetIntervalBuilder SetPictureWatermark(byte[] pictureFile);
    }
}
