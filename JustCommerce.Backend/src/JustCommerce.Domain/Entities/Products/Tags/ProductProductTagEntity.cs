using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Products.Tags
{
    public sealed class ProductProductTagEntity : Entity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = new ProductEntity();

        /// <summary>
        /// Gets or sets the product tag identifier
        /// </summary>
        public Guid ProductTagId { get; set; }
        public ProductTagEntity ProductTag { get; set; } = new ProductTagEntity();

    }
}
