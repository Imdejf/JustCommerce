using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Products.Manufacturer
{
    public class ProductManufacturerEntity 
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer identifier
        /// </summary>
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is featured
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
