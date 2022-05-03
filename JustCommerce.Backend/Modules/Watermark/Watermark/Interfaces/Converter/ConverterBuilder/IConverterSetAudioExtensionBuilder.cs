namespace Watermark.Interfaces.Converter.ConverterBuilder
{
    public interface IConverterSetAudioExtensionBuilder
    {
        IConverterSetTypeBuilder AsWav();
        IConverterSetTypeBuilder AsMp3();
        IConverterSetTypeBuilder AsFlac();
    }
}
