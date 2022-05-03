using Watermark.Configs.Abstract;
using Watermark.Enums;
using Watermark.Interfaces.WatermarkBuilder.Common;

namespace Watermark.Implementations.WatermarkConfigBuilder.Abstarct
{
    public abstract class AbstractWatermarkConfigBuilder<T> : IAbstractWatermarkConfigBuilder<T>
        where T : IAbstractWatermarkConfigBuilder<T>
    {
        protected CommonConfig _properties;
        public AbstractWatermarkConfigBuilder()
        {
            
        }
        public AbstractWatermarkConfigBuilder(CommonConfig properties)
        {
            _properties = properties;
        }

        public T SetOperation(WatermarkOperation operation)
        {
            _properties.Operation = operation;
            return (T)(IAbstractWatermarkConfigBuilder<T>)this;
        }
    }
}
