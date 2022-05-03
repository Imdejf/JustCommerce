using System.Collections.Generic;

namespace Watermark.Interfaces.Tools
{
    internal interface IWavSoundCutter
    {
        List<byte[]> Cut(byte[] musicArray, int intervalBetweenSound, int totalTimeSeconds);
        List<byte[]> CutAudioFromVideo(byte[] musicArray, int intervalBetweenSound, int totalMusicTimeSeconds, int totalSoundTimeSeconds);
    }
}
