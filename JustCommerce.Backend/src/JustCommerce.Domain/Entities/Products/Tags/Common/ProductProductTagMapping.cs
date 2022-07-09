using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Products.Tags.Common
{
    public sealed class ProductProductTagMapping : Entity
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
        public ProductTagLangEntity ProductTagLang { get; set; } = new ProductTagLangEntity();

    }
}
