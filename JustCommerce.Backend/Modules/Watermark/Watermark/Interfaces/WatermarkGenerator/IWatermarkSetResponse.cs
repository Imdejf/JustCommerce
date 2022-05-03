using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Watermark.Interfaces.WatermarkGenerator
{
    public interface IWatermarkSetResponse
    {
        Stream AsStream();
        Task<Stream> AsStreamAsync(CancellationToken cancellationToken = default);
        byte[] AsByteArray();
        Task<byte[]> AsByteArrayAsync(CancellationToken cancellationToken = default);
        string AsBase64File();
        Task<string> AsBase64FileAsync(CancellationToken cancellationToken = default);
    }
}
