using System.IO;

namespace Watermark.Interfaces.Converter.ConverterBuilder
{
    public interface IConverterSetTypeBuilder
    {
        Stream AsStream();
        byte[] AsByteArray();
        string AsBase64File();
    }
}
