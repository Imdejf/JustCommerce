namespace Watermark.Interfaces.Converter.ConverterBuilder
{
    public interface IConverterSetVideoExtensionBuilder
    {
        IConverterSetVideoOperationBuilder AsMp3();
        IConverterSetVideoOperationBuilder AsWav();
        IConverterSetVideoOperationBuilder AsMp4();
    }
}
