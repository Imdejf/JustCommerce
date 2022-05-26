using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Domain.Entities.Order;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Product
{
    public sealed class ProductSellableEntity : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
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
        public string IconPath { get; set; }
        public ICollection<OfferItemEntity> OfferItem { get; set; }
        public ICollection<OrderItemEntity> OrderItem { get; set; } 
    }
}
