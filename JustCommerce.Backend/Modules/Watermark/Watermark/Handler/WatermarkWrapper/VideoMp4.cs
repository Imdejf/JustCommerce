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
    /// Default implementation class of <see cref="IWatermarkHandler"/> for .mp4 file
    /// </summary>
    internal sealed class VideoMp4 : WatermarkGenerator<WatermarkVideoConfig>, IWatermarkHandler
    {
        public WatermarkFileType Type { get; set; } = WatermarkFileType.MP4;

        private readonly IWavSoundComparer _wavSoundComparer;
        private readonly IWavSoundCutter _wavSoundCutter;
        private readonly IWavSoundConcatenater _wavSoundConcatenater;
        private readonly IWavSoundMixer _wavSoundMixer;
        private readonly IConverterBuilder _converterBuilder;        

        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="soundHelper"><see cref="IWatermarkSoundHelper "/> added in DI container</param>
        /// <param name="converterBuilder"><see cref="IConverterBuilder "/> added in DI container</param>
        /// <param name="config"><see cref="WatermarkVideoConfig"/> configured in DI container</param>
        public VideoMp4(IConverterBuilder converterBuilder, IOptions<WatermarkVideoConfig> config, IWavSoundComparer wavSoundComparer, IWavSoundCutter wavSoundCutter, IWavSoundConcatenater wavSoundConcatenater, IWavSoundMixer wavSoundMixer)
            : base(config.Value)
        {
            _FuncsMap = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>
            {
                {WatermarkOperation.AddPicture, addPicture },
                {WatermarkOperation.AddSound, changeSound },
            };
            _converterBuilder = converterBuilder;            
            _wavSoundComparer = wavSoundComparer;
            _wavSoundCutter = wavSoundCutter;
            _wavSoundConcatenater = wavSoundConcatenater;
            _wavSoundMixer = wavSoundMixer;
        }
        /// <summary>
        /// Main method for adding watermark to .mp4 file
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
        
        private MemoryStream changeSound(byte[] inputFile)
        {
            WatermarkFileType soundExtension = WatermarkHelper.GetTypeOfFile(_Config.Sound);
            if (soundExtension == WatermarkFileType.FLAC || soundExtension == WatermarkFileType.MP3)
            {
                _Config.Sound = _converterBuilder.OnAudioFile(_Config.Sound)
                                                 .AsWav()
                                                 .AsByteArray();
            }

            var audio = _converterBuilder.OnVideoFile(inputFile)
                                         .AsWav()
                                         .GetAudio()
                                         .AsByteArray();            
            
            WaveFileReader audioFile = new WaveFileReader(new MemoryStream(audio));

            var soundWav = _wavSoundComparer.CompareWavFile(
                _Config.Sound,
                audioFile.WaveFormat.SampleRate,
                audioFile.WaveFormat.BitsPerSample,
                audioFile.WaveFormat.Channels);
            WaveFileReader soundFile = new WaveFileReader(new MemoryStream(soundWav));

            var cutMusic = _wavSoundCutter.CutAudioFromVideo(audio, _Config.IntervalBetweenSound, (int)audioFile.TotalTime.TotalSeconds, (int)soundFile.TotalTime.TotalSeconds);
            var mixedMusic = _wavSoundMixer.MixMusicWithSound(cutMusic, soundWav);

            using (var output = new MemoryStream())
            {
                _wavSoundConcatenater.Concatenate(output, mixedMusic);

                var newVideo = _converterBuilder.OnVideoFile(inputFile)
                                                .AsMp4()
                                                .ChangeAudio(output.ToArray())
                                                .AsByteArray();

                return new MemoryStream(newVideo);
            }
        }
        private MemoryStream addPicture(byte[] inputFile) 
        {            
            var bytes = _converterBuilder.OnVideoFile(inputFile)
                                         .AsMp4()
                                         .AddPicture(_Config.Image)
                                         .AsByteArray();

            return new MemoryStream(bytes);
        }
    }
}
