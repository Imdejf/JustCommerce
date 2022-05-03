using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using Watermark.Configs;
using Watermark.Enums;
using Watermark.Implementations.Tools;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.Handler.WatermarkWrapper
{
    /// <summary>
    /// Default implementation class of <see cref="IWatermarkHandler"/> for .pdf file
    /// </summary>
    internal sealed class FilePdf : WatermarkGenerator<WatermarkTextFileConfig>, IWatermarkHandler
    {
        public WatermarkFileType Type { get; } = WatermarkFileType.PDF;
                     
        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="options"><see cref="WatermarkTextFileConfig"/> configured in DI container</param>
        /// <param name="textFileHelper"><see cref="IWatermarkTextFileHelper"/> added in DI container</param>
        public FilePdf(IOptions<WatermarkTextFileConfig> options) : base(options.Value)
        {
            _FuncsMap = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>()
            {
                { WatermarkOperation.AddPicture, addPictureWatermarkToPdf },
                { WatermarkOperation.AddText, addTextWatermarkToPdf }
            };
        }
        
        private MemoryStream addPictureWatermarkToPdf(byte[] fileInput)
        {
            var img = Image.GetInstance(_Config.ImageWatermark);
            using (var pdfDocument = new PdfReader(fileInput))
            {
                var sizeOfPage = pdfDocument.GetPageSize(1);
                (int x, int y) = WatermarkHelper.GetPositionForImage((int)sizeOfPage.Width, (int)sizeOfPage.Height, (int)img.Width, (int)img.Height, WatermarkPosition.Center, _Config.Margin);
                img.SetAbsolutePosition(x, y);

                PdfContentByte watermark;

                using (MemoryStream stream = new MemoryStream())
                {
                    using (PdfStamper stamper = new PdfStamper(pdfDocument, stream))
                    {
                        int pages = pdfDocument.NumberOfPages;
                        for (int i = 1; i <= pages; i++)
                        {
                            watermark = stamper.GetUnderContent(i);
                            watermark.AddImage(img);
                        }
                    }
                    return stream;
                }
            }
        }
        private MemoryStream addTextWatermarkToPdf(byte[] fileInput)
        {
            using (var ms = new MemoryStream(10 * 1024))
            {
                using (var reader = new PdfReader(fileInput))
                using (var stamper = new PdfStamper(reader, ms))
                {
                    var pages = reader.NumberOfPages;
                    for (var i = 1; i <= pages; i++)
                    {
                        var dc = stamper.GetOverContent(i);
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        addTextWatermark(dc,
                            _Config.TextWatermark,
                            bfTimes,
                            _Config.FontSize,
                            45,
                            BaseColor.GRAY,
                            reader.GetPageSizeWithRotation(i),
                            _Config);
                    }
                    stamper.Close();
                }
                return ms;
            }
        }
        private void addTextWatermark(PdfContentByte pdfData,
            string? watermarkText,
            BaseFont font,
            float fontSize,
            float angle,
            BaseColor color,
            iTextSharp.text.Rectangle realPageSize,
            WatermarkTextFileConfig config)
        {
            (float x, float y) = WatermarkHelper.GetPositionForText(realPageSize.Width, realPageSize.Height, WatermarkPosition.Center, config.FontSize, config.Margin);
            var gstate = new PdfGState { FillOpacity = config.Opacity, StrokeOpacity = 0.3f };
            pdfData.SaveState();
            pdfData.SetGState(gstate);
            pdfData.SetColorFill(color);
            pdfData.BeginText();
            pdfData.SetFontAndSize(font, fontSize);
            pdfData.ShowTextAligned(Element.ALIGN_CENTER, watermarkText, x, y, angle);
            pdfData.EndText();
            pdfData.RestoreState();
        }
        
    }
}
