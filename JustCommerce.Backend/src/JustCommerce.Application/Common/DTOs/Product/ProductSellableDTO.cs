using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.DTOs.Product
{
    public class ProductSellableDTO
    {
        public Guid ProductId { get; set; }
        public Currency Currency { get; set; }
        public ProductColor ProductColor { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal ProducentPrice { get; set; }
        public decimal Weight { get; set; }
        public string ProductNumber { get; set; }
        public string EanCode { get; set; }
        public string? IconPath { get; set; }
        public Base64File? Base64File { get; set; }
        public string? FileName { get; set; }
    }
}
