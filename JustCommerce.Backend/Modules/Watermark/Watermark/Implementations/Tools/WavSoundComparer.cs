using NAudio.Wave;
using System.IO;
using Watermark.Interfaces.Tools;

namespace Watermark.Implementations.Tools
{
    internal sealed class WavSoundComparer : IWavSoundComparer
    {
        public byte[] CompareWavFile(byte[] wavFile, int rate, int bits, int channels)
        {
            var target = new WaveFormat(rate, bits, channels);
            using (var outPutStream = new MemoryStream())
            using (var waveStream = new WaveFileReader(new MemoryStream(wavFile)))
            using (var conversionStream = new WaveFormatConversionStream(target, waveStream))
            {
                WaveFileWriter.WriteWavFileToStream(outPutStream, conversionStream);
                return outPutStream.ToArray();
            }
        }
    }
}
