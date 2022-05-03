using Watermark.Configs;
using Watermark.Implementations.WatermarkConfigBuilder.Abstarct;
using Watermark.Interfaces.WatermarkBuilder.Video;

namespace Watermark.Implementations.WatermarkConfigBuilder.Video
{
    internal sealed class WatermarkVideoConfigBuilder :
        AbstractWatermarkConfigBuilder<IWatermarkVideoSetWatermarkBuilder>,
        IWatermarkVideoSetWatermarkBuilder,
        IWatermarkVideoSetIntervalBuilder
    {
        private static WatermarkVideoConfig _config;
        public WatermarkVideoConfigBuilder()
        {
            _config = new WatermarkVideoConfig();
            base._properties = _config;
        }        

        public WatermarkVideoConfig Build() => _config;

        public void SetInterval(int interval = 30)
        {
            _config.IntervalBetweenSound = interval;
        }

        public IWatermarkVideoSetIntervalBuilder SetPictureWatermark(byte[] pictureFile)
        {
            _config.Image = pictureFile;
            return this;
        }

        public IWatermarkVideoSetIntervalBuilder SetSoundWatermark(byte[] soundFile)
        {
            _config.Sound = soundFile;
            return this;
        }
    }
}
