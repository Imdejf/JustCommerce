using System;
using System.IO;
using Watermark.Configs.Abstract;
using Watermark.Enums;

namespace Watermark.Configs
{
    public sealed class WatermarkSoundConfig : CommonConfig
    {
        /// <summary>
        /// Gets or sets operation
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value not equal AddSound</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is AddSound</para>
        /// </summary>
        public override WatermarkOperation Operation 
        {
            get { return _operation; }
            set 
            {
                if (value != WatermarkOperation.AddSound)
                    throw new ArgumentException("Send not corrent operation for sound file");
                _operation = value;
            } 
        }
        private WatermarkOperation _operation;
        /// <summary>
        /// Gets or sets interval for sound in music
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value less than 0</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is 30</para>
        /// </summary>
        public int IntervalBetweenSound 
        {
            get { return _intervalBetweenSound; }
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Interval between sound and music can't be less than 0 seconds");
                _intervalBetweenSound = value;
            } 
        }
        private int _intervalBetweenSound;
        /// <summary>
        /// Gets or sets sound watermark 
        /// <para>Default value is our sound</para>
        /// </summary>
        public byte[] Sound { get; set; } 
        public WatermarkSoundConfig()
        {
            this.Operation = WatermarkOperation.AddSound;
            this.IntervalBetweenSound = 30;
            this.Sound = File.ReadAllBytes(Directory.GetCurrentDirectory().Split("src")[0] + @"\\Modules\\Watermark\\Watermark\\Resources\\WatermarkSounds\\DataSharp.wav");
        }
    }
}
