using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.DTOs.Product
{
    public class ProductFileDTO
    {
        public string FileName { get; set; }
        public Base64File Base64File { get; set; }
        public ProductColor ProductColor { get; set; }
    }
}
