using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class ProductAttributeCombinationEntity : Entity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        /// <summary>
        /// Gets or sets the attributes
        /// </summary>
        public ICollection<ProductAttributeEntity> ProductAttribute { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow orders when out of stock
        /// </summary>
        public bool AllowOutOfStockOrders { get; set; }

        /// <summary>
        /// Gets or sets the SKU
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer part number
        /// </summary>
        public string ManufactureraPrtNumber { get; set; }

        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// Gets or sets the attribute combination price. This way a store owner can override the default product price when this attribute combination is added to the cart. For example, you can give a discount this way.
        /// </summary>
        public decimal? OverriddenPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity when admin should be notified
        /// </summary>
        public int NotifyAdminForQuantityBelow { get; set; }

        /// <summary>
        /// Gets or sets the identifier of picture associated with this combination
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the minimum stock quantity
        /// </summary>
        public int MinStockQuantity { get; set; }
    }
}
