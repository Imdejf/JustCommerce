using Watermark.Enums;

namespace Watermark.Interfaces.WatermarkBuilder.Common
{
    public interface IAbstractWatermarkConfigBuilder<TAbstarctWatermark>
        where TAbstarctWatermark : IAbstractWatermarkConfigBuilder<TAbstarctWatermark>
    {
        TAbstarctWatermark SetOperation(WatermarkOperation operation);
    }
}
