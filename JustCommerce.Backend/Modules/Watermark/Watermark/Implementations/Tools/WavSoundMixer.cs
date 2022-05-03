using System.Collections.Generic;
using System.Linq;
using Watermark.Interfaces.Tools;

namespace Watermark.Implementations.Tools
{
    internal sealed class WavSoundMixer : IWavSoundMixer
    {
        public List<byte[]> MixMusicWithSound(IEnumerable<byte[]> cutMusic, byte[] sound)
        {
            List<byte[]> mixedMusic = new List<byte[]>();
            int count = 1;
            foreach(var music in cutMusic) 
            {
                if (cutMusic.ToList().Count <= count) 
                {
                    mixedMusic.Add(music);
                    break;
                }
                mixedMusic.Add(music);                
                mixedMusic.Add(sound);
                count++;
            }
            return mixedMusic;
        }
    }
}
