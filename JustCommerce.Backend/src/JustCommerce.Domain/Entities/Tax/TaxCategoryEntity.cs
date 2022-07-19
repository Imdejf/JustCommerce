using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Tax
{
    public class TaxCategoryEntity : Entity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
        public ICollection<ProductEntity> Product { get; set; }
    }
}
