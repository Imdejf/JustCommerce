using Watermark.Configs;
using Watermark.Enums;
using Watermark.Implementations.WatermarkConfigBuilder.Abstarct;
using Watermark.Interfaces.WatermarkBuilder.Image;

namespace Watermark.Implementations.WatermarkConfigBuilder.Image
{
    internal sealed class WatermarkImageConfigBuilder :
        AbstractWatermarkConfigBuilder<IWatermarkImageSetWatermarkBuilder>,
        IWatermarkImageSetWatermarkBuilder,
        IWatermarkImageSetOpacityBuilder,
        IWatermarkImageSetWatermarkPositionBuilder,
        IWatermarkImageSetMarginBuilder,
        IWatermarkImageSetFontSizeBuilder        
    {
        private WatermarkImageConfig _config;
        public WatermarkImageConfigBuilder()
        {
            _config = new WatermarkImageConfig();
            base._properties = _config;
        }        

        public WatermarkImageConfig Build() => _config;

        public void SetFontSize(float fontSize = 100)
        {
            _config.FontSize = fontSize;
        }

        public IWatermarkImageSetFontSizeBuilder SetMargin(int margin = 0)
        {
            _config.Margin = margin;
            return this;
        }

        public IWatermarkImageSetMarginBuilder SetOpacity(float opacity = 0.5F)
        {
            _config.Opacity = opacity;
            return this;
        }

        public IWatermarkImageSetWatermarkPositionBuilder SetPictureWatermark(byte[] watermarkImage)
        {
            _config.WatermarkImage = watermarkImage;            
            return this;
        }

        public IWatermarkImageSetWatermarkPositionBuilder SetTextWatermark(string watermarkText = "MugoPl")
        {
            _config.WatermarkText = watermarkText;            
            return this;
        }

        public IWatermarkImageSetOpacityBuilder SetWatermarkPosition(WatermarkPosition position = WatermarkPosition.Center)
        {
            _config.WatermarkPosition = position;
            return this;
        }
    }
}
