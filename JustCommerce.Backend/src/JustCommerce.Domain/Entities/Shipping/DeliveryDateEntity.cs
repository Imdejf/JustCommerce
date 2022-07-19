using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Language;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Shipping
{
    public class DeliveryDateEntity : Entity 
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
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}
