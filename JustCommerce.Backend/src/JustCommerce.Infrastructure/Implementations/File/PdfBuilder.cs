using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Domain.Entities.Order;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Infrastructure.Implementations.File.Model;
using JustCommerce.Shared.Models;
using Microsoft.Extensions.Options;
using PdfSharp;
using PdfSharp.Pdf;
using System.Net;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace JustCommerce.Infrastructure.Implementations.File
{
    internal class PdfBuilder : IPdfBuilder
    {
        private readonly FtpFileConfig _ftpFileConfig;
        public PdfBuilder(IOptions<FtpFileConfig> ftpFileConfig)
        {
            _ftpFileConfig = ftpFileConfig.Value;
        }

        public async Task<byte[]> OrderGenerate(OrderEntity order)
        {
            byte[] file = null;
            string htmlTemplate = System.IO.File.ReadAllText("PdfTemplates/Order.html");

            List<PdfBuilderModel> pdfBuilders = new List<PdfBuilderModel>();

            foreach(var item in order.OrderItem)
            {
                var base64File = await getIconFromFtpAsync(item.ProductSellable.IconPath);
                pdfBuilders.Add(new PdfBuilderModel
                {
                    base64File = base64File,
                    GrossPrice = item.GrossPrice,
                    NettoPrice = item.NettoPrice,
                    Quantity = item.Quantity,
                    Tax = item.Tax
                });
            }

            StringBuilder sb = new StringBuilder(htmlTemplate);

            sb.Replace("@CREATEDATE", order.CreatedDate?.ToString("dd/MM/yyyy"));
            sb.Replace("[ORDERNUMBER]", order.OrderNumber.ToString());
            sb.Replace("@CUSTOMERNAME", order.CustomerName);
            sb.Replace("@CUSTOMEREMAIL", order.CustomerEmail);
            sb.Replace("@CUSTOMERPHONE", order.CustomerPhone);

            string orderTable = await createTableAsync(pdfBuilders);

            sb.Replace("@OFFERTABLE", orderTable);

            PdfDocument pdfDocument = PdfGenerator.GeneratePdf(sb.ToString(), PageSize.A4);
            using (MemoryStream stream = new MemoryStream())
            {
                pdfDocument.Save(stream, true);
                file = stream.ToArray();
            }

            return file;
        }

        public async Task<byte[]> OfferGenerate(OfferEntity offer)
        {
            byte[] file = null;
            string htmlTemplate = System.IO.File.ReadAllText("PdfTemplates/Offer.html");

            List<PdfBuilderModel> pdfBuilders = new List<PdfBuilderModel>();

            foreach (var item in offer.OfferItem)
            {
                var base64File = await getIconFromFtpAsync(item.ProductSellable.IconPath);
                pdfBuilders.Add(new PdfBuilderModel
                {
                    base64File = base64File,
                    GrossPrice = item.GrossPrice,
                    NettoPrice = item.NettoPrice,
                    Quantity = item.Quantity,
                    Tax = item.Tax
                });
            }

            StringBuilder sb = new StringBuilder(htmlTemplate);

            sb.Replace("@CREATEDATE", offer.CreatedDate?.ToString("dd/MM/yyyy"));
            sb.Replace("@OFFERNUMBER", offer.OfferNumber.ToString());
            sb.Replace("@CUSTOMERNAME", offer.CustomerName);
            sb.Replace("@CUSTOMEREMAIL", offer.CustomerEmail);
            sb.Replace("@CUSTOMERPHONE", offer.CustomerPhone);

            string offerTable = await createTableAsync(pdfBuilders);

            sb.Replace("@OFFERTABLE", offerTable);

            PdfDocument pdfDocument = PdfGenerator.GeneratePdf(sb.ToString(), PageSize.A4);
            using(MemoryStream stream = new MemoryStream())
            {
                pdfDocument.Save(stream, true);
                file = stream.ToArray();
            }

            return file;
        }

        private async Task<string> createTableAsync(List<PdfBuilderModel> pdfBuilders)
        {
            StringBuilder sb = new StringBuilder();
            int lp = 1;

            foreach(var item in pdfBuilders)
            {
                sb.Append($"<tr><td>{lp}</td><td><img src='data:image/{item.base64File.FileExtension};base64, {item.base64File.Base64String}' /></td><td>Name</td><td>{item.Quantity}</td><td>{item.Quantity / item.NettoPrice}</td><td>{item.GrossPrice}</td><td>{item.Tax}</td><td>{item.NettoPrice}</td></tr>");
                lp++;
            }

            return sb.ToString();
        }

        private async Task<Base64File> getIconFromFtpAsync(string iconPath)
        {
            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(_ftpFileConfig.UserId, _ftpFileConfig.Password);
                byte[] fileData = await request.DownloadDataTaskAsync(iconPath);
                Base64File base64File = new Base64File(Convert.ToBase64String(fileData));
                return base64File;
            }
        }
    }
}
