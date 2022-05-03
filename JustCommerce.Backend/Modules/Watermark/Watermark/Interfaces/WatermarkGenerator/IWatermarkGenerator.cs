using System.IO;

namespace Watermark.Interfaces.WatermarkGenerator
{
    public interface IWatermarkGenerator
    {
        IWatermarkSetResponse OnFile(byte[] array);
        IWatermarkSetResponse OnFile(MemoryStream stream);
        IWatermarkSetResponse OnFile(string base64File);
    }
}
