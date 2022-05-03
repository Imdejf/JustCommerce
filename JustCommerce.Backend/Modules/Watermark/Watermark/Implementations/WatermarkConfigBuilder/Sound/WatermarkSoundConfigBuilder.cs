using Watermark.Configs;
using Watermark.Implementations.WatermarkConfigBuilder.Abstarct;
using Watermark.Interfaces.WatermarkBuilder.Sound;

namespace Watermark.Implementations.WatermarkConfigBuilder.Sound
{
    internal sealed class WatermarkSoundConfigBuilder : 
        AbstractWatermarkConfigBuilder<IWatermarkSoundSetWatermarkBuilder>,
        IWatermarkSoundSetWatermarkBuilder,   
        IWatermarkSoundSetIntervalBuilder
    {
        private WatermarkSoundConfig _config;
        public WatermarkSoundConfigBuilder()
        {
            _config = new WatermarkSoundConfig();
            base._properties = _config;
        }

        public WatermarkSoundConfig Build() => _config;        

        public void SetInterval(int interval = 30)
        {
            _config.IntervalBetweenSound = 30;
        }

        public IWatermarkSoundSetIntervalBuilder SetSoundWatermark(byte[] sound)
        {
            _config.Sound = sound;
            return this;
        }
    }
}
