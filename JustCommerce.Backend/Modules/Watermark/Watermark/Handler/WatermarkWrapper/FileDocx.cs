using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Watermark.Configs;
using Watermark.Enums;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.Handler.WatermarkWrapper
{
    /// <summary>
    /// Default implementation class of <see cref="IWatermarkHandler"/> for .docx file
    /// </summary>
    internal sealed class FileDocx : WatermarkGenerator<WatermarkTextFileConfig>, IWatermarkHandler
    {
        public WatermarkFileType Type { get; } = WatermarkFileType.DOCX;

        private string imagePart1Data;

        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="configOptions"><see cref="WatermarkTextFileConfig"/> configured in DI container</param>
        /// <param name="textFileHelper"><see cref="IWatermarkTextFileHelper"/> added id DI container</param>
        public FileDocx(IOptions<WatermarkTextFileConfig> options) : base(options.Value)
        {
            _FuncsMap = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>()
            {
                { WatermarkOperation.AddPicture, addPictureWatermarkToDocx },
                { WatermarkOperation.AddText, addTextWatermarkToDocx }
            };
            imagePart1Data = "";            
        }


        private MemoryStream addPictureWatermarkToDocx(byte[] fileInput)
        {
            byte[] updatedFile;
            using (var fileStream = new MemoryStream(fileInput))
            {
                WordprocessingDocument package = WordprocessingDocument.Open(fileStream, true);
                insertCustomWatermark(package, _Config.ImageWatermark);
                using (var save = new MemoryStream())
                {
                    package.Clone(save);
                    updatedFile = save.ToArray();
                }
            }
            return new MemoryStream(updatedFile);
        }
        private MemoryStream addTextWatermarkToDocx(byte[] fileInput)
        {
            byte[] updatedFile;
            using (var textToImage = new MemoryStream())
            {
                var image = convertTextToImage(_Config.TextWatermark, "Bookman Old Style", (int)_Config.FontSize, System.Drawing.Color.Black, 210, 297);
                image.Save(textToImage, ImageFormat.Png);

                using (var fileStream = new MemoryStream(fileInput))
                {
                    WordprocessingDocument package = WordprocessingDocument.Open(fileStream, true);
                    insertCustomWatermark(package, textToImage.ToArray());
                    using (var save = new MemoryStream())
                    {
                        package.Clone(save);
                        updatedFile = save.ToArray();
                    }
                }
                return new MemoryStream(updatedFile);
            }
        }

        
        private Bitmap convertTextToImage(string txt, string fontname, int fontsize, System.Drawing.Color fcolor, int width, int Height)
        {
            Bitmap bmp = new Bitmap(width, Height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {

                using (System.Drawing.Font font = new System.Drawing.Font(fontname, fontsize))
                {
                    graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
                    graphics.Flush();
                }
            }
            return bmp;
        }                

        private void insertCustomWatermark(WordprocessingDocument package, byte[] pictureBytes)
        {
            setWaterMarkPicture(pictureBytes);
            MainDocumentPart mainDocumentPart1 = package.MainDocumentPart;
            if (mainDocumentPart1 != null)
            {
                mainDocumentPart1.DeleteParts(mainDocumentPart1.HeaderParts);
                HeaderPart headPart1 = mainDocumentPart1.AddNewPart<HeaderPart>();
                generateHeaderPictureContent(headPart1);

                string rId = mainDocumentPart1.GetIdOfPart(headPart1);
                ImagePart image = headPart1.AddNewPart<ImagePart>("image/jpeg", "rId999");
                generateImageContent(image);

                IEnumerable<SectionProperties> sectPrs = mainDocumentPart1.Document.Body.Elements<SectionProperties>();
                foreach (var sectPr in sectPrs)
                {
                    sectPr.RemoveAllChildren<HeaderReference>();
                    sectPr.PrependChild<HeaderReference>(new HeaderReference() { Id = rId });
                }
            }
        }

        private void generateHeaderPictureContent(HeaderPart headerPart1)
        {
            DocumentFormat.OpenXml.Wordprocessing.Header header = new DocumentFormat.OpenXml.Wordprocessing.Header();
            DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            Run run1 = new Run();
            Picture picture = new Picture();

            DocumentFormat.OpenXml.Vml.Shape shape = new DocumentFormat.OpenXml.Vml.Shape() { Id = "WordPictureWatermark75517470", Style = "position:absolute;val:100pt;left:0;text-align:left;margin-left:0;margin-top:0;width:415.2pt;height:456.15pt;z-index:-251656192;mso-position-horizontal:center;mso-position-horizontal-relative:margin;mso-position-vertical:center;mso-position-vertical-relative:margin", OptionalString = "_x0000_s2051", AllowInCell = false, Type = "#_x0000_t75" };
            ImageData imageData = new ImageData() { Gain = "19661f", BlackLevel = "22938f", Title = "??", RelationshipId = "rId999" };

            shape.Append(imageData);
            picture.Append(shape);
            run1.Append(picture);
            paragraph.Append(run1);
            header.Append(paragraph);
            headerPart1.Header = header;
        }
        private void generateImageContent(ImagePart imagePart1)
        {
            System.IO.Stream data = getBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        private Stream getBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }
        private void setWaterMarkPicture(byte[] pBytes)
        {
            try
            {
                imagePart1Data = Convert.ToBase64String(pBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
