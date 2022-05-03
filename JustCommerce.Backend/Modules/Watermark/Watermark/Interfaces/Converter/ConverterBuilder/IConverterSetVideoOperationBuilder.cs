namespace Watermark.Interfaces.Converter.ConverterBuilder
{
    public interface IConverterSetVideoOperationBuilder
    {
        IConverterSetTypeBuilder GetAudio();        
        IConverterSetTypeBuilder ChangeAudio(byte[] inputFile);
        IConverterSetTypeBuilder AddPicture(byte[] pictureWatermark);
    }
}
