using Watermark.Configs;
using Watermark.Implementations.WatermarkConfigBuilder.Abstarct;
using Watermark.Interfaces.WatermarkBuilder.File;

namespace Watermark.Implementations.WatermarkConfigBuilder.File
{
    internal sealed class WatermarkTextFileConfigBuilder :
        AbstractWatermarkConfigBuilder<IWatermarkTextFileSetWatermarkBuilder>, 
        IWatermarkTextFileSetWatermarkBuilder,       
        IWatermarkTextFileSetFontSizeBuilder,
        IWatermarkTextFileSetMarginBuilder,
        IWatermarkTextFileSetOpacityBuilder      
    {
        private WatermarkTextFileConfig _config;
        public WatermarkTextFileConfigBuilder()
        {
            _config = new WatermarkTextFileConfig();
            base._properties = _config;
        }        

        public WatermarkTextFileConfig Build() => _config;        

        public void SetFontSize(float fontSize = 20)
        {
            _config.FontSize = fontSize;
        }

        public IWatermarkTextFileSetFontSizeBuilder SetMargin(int margin = 20)
        {
            _config.Margin = margin;
            return this;
        }

        public IWatermarkTextFileSetMarginBuilder SetOpacity(float opacity = 0.5F)
        {
            _config.Opacity = opacity;
            return this;
        }

        public IWatermarkTextFileSetOpacityBuilder SetPictureWatermark(byte[] imageWatermark)
        {
            _config.ImageWatermark = imageWatermark;
            return this;
        }        

        public IWatermarkTextFileSetOpacityBuilder SetTextWatermark(string textWatermark = "DataSharp")
        {
            _config.TextWatermark = textWatermark;
            return this;
        }
    }
}
