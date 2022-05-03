using System.Collections.Generic;

namespace Watermark.Interfaces.Tools
{
    internal interface IWavSoundMixer
    {
        List<byte[]> MixMusicWithSound(IEnumerable<byte[]> cutMusic, byte[] sound);
    }
}
