using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Interfaces.WatermarkBuilder.Sound
{
    public interface IWatermarkSoundSetWatermarkBuilder : IAbstractWatermarkConfigBuilder<IWatermarkSoundSetWatermarkBuilder>
    {
        IWatermarkSoundSetIntervalBuilder SetSoundWatermark(byte[] sound);        
    }
}
