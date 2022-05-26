using JustCommerce.Shared.Models;

namespace JustCommerce.Infrastructure.Implementations.File.Model
{
    internal sealed class PdfBuilderModel
    {
        public Base64File base64File { get; set; }
        public int Quantity { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal Tax { get; set; }
    }
}
