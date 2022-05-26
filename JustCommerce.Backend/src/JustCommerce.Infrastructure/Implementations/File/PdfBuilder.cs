using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Net;
using System.Text;
using PdfSharp.Drawing;
using System.Drawing;
using JustCommerce.Shared.Models;
using JustCommerce.Domain.Entities.Order;

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

            StringBuilder sb = new StringBuilder(htmlTemplate);

            sb.Replace("@CREATEDATE", order.CreatedDate?.ToString("dd/MM/yyyy"));
            sb.Replace("[ORDERNUMBER]", order.OrderNumber.ToString());
            sb.Replace("@CUSTOMERNAME", order.CustomerName);
            sb.Replace("@CUSTOMEREMAIL", order.CustomerEmail);
            sb.Replace("@CUSTOMERPHONE", order.CustomerPhone);

            string orderTable = await addItemsToOffertAsync(order);

            sb.Replace("@OFFERTABLE", orderTable);
        }

        private async Task<string> addItemsToOffertAsync(OrderEntity order)
        {
            StringBuilder sb = new StringBuilder();
            int lp = 1;

            foreach (var offerItem in order.)
            {
                var base64File = await getIconFromFtpAsync(offerItem.ProductSellable.IconPath);

                sb.Append($"<tr><td>{lp}</td><td><img src='data:image/{base64File.FileExtension};base64, {base64File.Base64String}' /></td><td>Name</td><td>{offerItem.Quantity}</td><td>{offerItem.Quantity / offerItem.NettoPrice}</td><td>{offerItem.GrossPrice}</td><td>{offerItem.Tax}</td><td>{offerItem.NettoPrice}</td></tr>");
                lp++;
            }

            return sb.ToString();
        }

        public async Task<byte[]> OfferGenerate(OfferEntity offer)
        {
            byte[] file = null;
            string htmlTemplate = System.IO.File.ReadAllText("PdfTemplates/Offer.html");

            StringBuilder sb = new StringBuilder(htmlTemplate);

            sb.Replace("@CREATEDATE", offer.CreatedDate?.ToString("dd/MM/yyyy"));
            sb.Replace("@OFFERNUMBER", offer.OfferNumber.ToString());
            sb.Replace("@CUSTOMERNAME", offer.CustomerName);
            sb.Replace("@CUSTOMEREMAIL", offer.CustomerEmail);
            sb.Replace("@CUSTOMERPHONE", offer.CustomerPhone);

            string offerTable = await addItemsToOffertAsync(offer);

            sb.Replace("@OFFERTABLE", offerTable);

            PdfDocument pdfDocument = PdfGenerator.GeneratePdf(sb.ToString(), PageSize.A4);
            using(MemoryStream stream = new MemoryStream())
            {
                pdfDocument.Save(stream, true);
                file = stream.ToArray();
            }

            return file;
        }

        private async Task<string> addItemsToOffertAsync(OfferEntity offer)
        {
            StringBuilder sb = new StringBuilder();
            int lp = 1;

            foreach(var offerItem in offer.OfferItem)
            {
                var base64File = await getIconFromFtpAsync(offerItem.ProductSellable.IconPath);

                sb.Append($"<tr><td>{lp}</td><td><img src='data:image/{base64File.FileExtension};base64, {base64File.Base64String}' /></td><td>Name</td><td>{offerItem.Quantity}</td><td>{offerItem.Quantity / offerItem.NettoPrice}</td><td>{offerItem.GrossPrice}</td><td>{offerItem.Tax}</td><td>{offerItem.NettoPrice}</td></tr>");
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
