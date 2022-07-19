using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Shipping;

namespace JustCommerce.Domain.Entities.Products.Product
{
    public sealed class ProductWarehouseInventoryEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        /// <summary>
        /// Gets or sets the warehouse identifier
        /// </summary>
        public Guid WarehouseId { get; set; }
        public WarehouseEntity Warehouse { get; set; } 
        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the reserved quantity (ordered but not shipped yet)
        /// </summary>
        public int ReservedQuantity { get; set; }
    }
}
