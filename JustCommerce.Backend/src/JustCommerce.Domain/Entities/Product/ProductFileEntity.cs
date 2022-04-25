using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Product
{
    public class ProductFileEntity : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public ProductColor ProductColor { get; set; }
        public string? PhotoPath { get; set; }
    }
}
