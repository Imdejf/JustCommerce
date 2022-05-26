using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.Order
{
    public sealed class OrderItemEntity
    {
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public Guid ProductSellableId { get; set; }
        public ProductSellableEntity ProductSellable { get; set; }
        public int Quantity { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal ProducentPrice { get; set; }
    }
}
