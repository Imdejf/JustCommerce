using Microsoft.Extensions.Options;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using Watermark.Configs;
using Watermark.Enums;
using Watermark.Implementations.Tools;
using Watermark.Interfaces.Converter.ConverterBuilder;
using Watermark.Interfaces.Tools;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.Handler.WatermarkWrapper
{
    /// <summary>
    /// Default implementation class of <see cref="IWatermarkHandler"/> for .flac file
    /// </summary>
    internal sealed class SoundFlac : WatermarkGenerator<WatermarkSoundConfig>, IWatermarkHandler
    {
        public WatermarkFileType Type { get; set; } = WatermarkFileType.FLAC;

        private readonly IConverterBuilder _converterBuilder;
        private readonly IWavSoundComparer _wavSoundComparer;
        private readonly IWavSoundCutter _wavSoundCutter;
        private readonly IWavSoundConcatenater _wavSoundConcatenater;
        private readonly IWavSoundMixer _wavSoundMixer;        
        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="soundHelper"><see cref="IWatermarkSoundHelper "/> added in DI container</param>
        /// <param name="converterBuilder"><see cref="IConverterBuilder "/> added in DI container</param>
        /// <param name="config"><see cref="WatermarkSoundConfig"/> configured in DI container</param>
        public SoundFlac(IConverterBuilder converterBuilder, IOptions<WatermarkSoundConfig> config, IWavSoundComparer wavSoundComparer, IWavSoundCutter wavSoundCutter, IWavSoundConcatenater wavSoundConcatenater, IWavSoundMixer wavSoundMixer)
            : base(config.Value)
        {
            _FuncsMap = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>
            {
                {WatermarkOperation.AddSound, combine }
            };
            _converterBuilder = converterBuilder;            
            _wavSoundComparer = wavSoundComparer;
            _wavSoundCutter = wavSoundCutter;
            _wavSoundConcatenater = wavSoundConcatenater;
            _wavSoundMixer = wavSoundMixer;
        }

        /// <summary>
        /// Main method for adding watermark to .flac file
        /// </summary>
        /// <param name="array">
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentNullException"/></term>
        /// <description>If send null byte[]</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>bytes of file</returns>
        public override byte[] SetWatermark(byte[]? array)
        {
            if (array == null) 
            {
                throw new ArgumentNullException("bytes of file can't be null");
            }

            WatermarkFileType soundExtension = WatermarkHelper.GetTypeOfFile(_Config.Sound);
            if (soundExtension == WatermarkFileType.FLAC || soundExtension == WatermarkFileType.MP3)
            {
                _Config.Sound = _converterBuilder.OnAudioFile(_Config.Sound)
                                                 .AsWav()
                                                 .AsByteArray();
            }
            array = _converterBuilder.OnAudioFile(array)
                                     .AsWav()
                                     .AsByteArray();

            var newAudio = base.SetWatermark(array);

            return _converterBuilder.OnAudioFile(newAudio)
                                    .AsFlac()
                                    .AsByteArray();
        }

        private MemoryStream combine(byte[] musicArray)
        {
            WaveFileReader reader = new WaveFileReader(new MemoryStream(musicArray));
            int totalTimeSeconds = (int)reader.TotalTime.TotalSeconds;

            
            var soundBytes = _wavSoundComparer.CompareWavFile(_Config.Sound,
                reader.WaveFormat.SampleRate,
                reader.WaveFormat.BitsPerSample,
                reader.WaveFormat.Channels);

            var cutMusic = _wavSoundCutter.Cut(musicArray, _Config.IntervalBetweenSound, totalTimeSeconds);
            var mixedMusic = _wavSoundMixer.MixMusicWithSound(cutMusic, soundBytes);
            using (var output = new MemoryStream())
            {
                _wavSoundConcatenater.Concatenate(output, mixedMusic);
                return output;
            }
        }        
    }
}
