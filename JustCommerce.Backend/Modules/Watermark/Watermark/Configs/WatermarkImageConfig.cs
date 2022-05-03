using System;
using System.IO;
using Watermark.Configs.Abstract;
using Watermark.Enums;

namespace Watermark.Configs
{
    public sealed class WatermarkImageConfig : CommonConfig
    {
        /// <summary>
        /// Gets or sets margin for image or text watermark
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value less than 0</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is 20</para>
        /// </summary>
        public int Margin
        {
            get { return _margin; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Margin can't be less than 0");
                _margin = value;
            }
        }
        private int _margin;

        /// <summary>
        /// Gets or sets opacity for image watermark
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value less than 0</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is 0.5</para>
        /// </summary>
        public float Opacity
        {
            get { return _opacity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Opacity can't be less than 0");
                _opacity = value;
            }
        }
        private float _opacity;        
        /// <summary>
        /// Gets or sets font size for text watermark
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value less than 0</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is 20</para>
        /// </summary>
        public float FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Font size can't be less than 0");
                _fontSize = value;
            }
        }
        private float _fontSize;
        /// <summary>
        /// Gets or sets operation
        /// <para>
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentException"/></term>
        /// <description>If send value not equal AddPicture or AddText</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Default value is AddText</para>
        /// </summary>
        public override WatermarkOperation Operation
        {
            get { return _operation; }
            set
            {
                if (value != WatermarkOperation.AddPicture && value != WatermarkOperation.AddText)
                    throw new ArgumentException("You can't add sound as watermark to text file");
                _operation = value;
            }
        }
        private WatermarkOperation _operation;
        /// <summary>
        /// Gets or sets color of watermark text       
        /// <para>Default value is black</para>
        /// </summary>
        public string WatermarkTextColorHex { get; set; }
        /// <summary>
        /// Gets or sets watermark position 
        /// <para>Default value is center</para>
        /// </summary>
        public WatermarkPosition WatermarkPosition { get; set; }
        /// <summary>
        /// Gets or sets text watermark
        /// <para>Default value is DataSharp</para>
        /// </summary>
        public string? WatermarkText { get; set; } 
        /// <summary>
        /// Gets or sets image watermark 
        /// <para>Default value is our photo</para>
        /// </summary>
        public byte[]? WatermarkImage { get; set; } 

        public WatermarkImageConfig()
        {
            this.Margin = 20;
            this.Opacity = 0.5f;
            this.FontSize = 20;
            this.Operation = WatermarkOperation.AddText;
            this.WatermarkImage = File.ReadAllBytes(Directory.GetCurrentDirectory().Split("src")[0] + @"\\Modules\\Watermark\\Watermark\\Resources\\WatermarkImages\\1.jpg");
            this.WatermarkPosition = WatermarkPosition.Center;
            this.WatermarkText = "DataSharp";
            this.WatermarkTextColorHex = "000000";
        }
    }
}
