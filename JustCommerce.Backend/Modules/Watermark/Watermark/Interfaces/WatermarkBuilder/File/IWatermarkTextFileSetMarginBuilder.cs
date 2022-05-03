using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Interfaces.WatermarkBuilder.File
{
    public interface IWatermarkTextFileSetMarginBuilder
    {
        IWatermarkTextFileSetFontSizeBuilder SetMargin(int margin = 20);
    }
}
