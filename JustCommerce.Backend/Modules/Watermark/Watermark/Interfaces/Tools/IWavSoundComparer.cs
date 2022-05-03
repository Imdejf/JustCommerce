namespace Watermark.Interfaces.Tools
{
    internal interface IWavSoundComparer
    {
        byte[] CompareWavFile(byte[] wavFile, int rate, int bits, int channels);
    }
}
