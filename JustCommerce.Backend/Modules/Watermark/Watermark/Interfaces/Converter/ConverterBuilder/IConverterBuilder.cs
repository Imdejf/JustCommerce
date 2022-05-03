namespace Watermark.Interfaces.Converter.ConverterBuilder
{
    public interface IConverterBuilder
    {
        IConverterSetAudioExtensionBuilder OnAudioFile(byte[] inputFile);
        IConverterSetVideoExtensionBuilder OnVideoFile(byte[] inputFile);
    }
}
