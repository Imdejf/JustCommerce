using System.Threading;
using System.Threading.Tasks;
using Watermark.Enums;

namespace Watermark.Interfaces.WatermarkGenerator
{
    public interface IWatermarkHandler        
    {        
        WatermarkFileType Type { get; }

        byte[] SetWatermark(byte[]? array);
        Task<byte[]> SetWatermarkAsync(byte[]? array, CancellationToken cancellationToken = default);        
    }
}
