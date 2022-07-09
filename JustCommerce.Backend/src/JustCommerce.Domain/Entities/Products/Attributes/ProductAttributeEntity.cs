using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class ProductAttributeEntity : Entity
    {
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public List<ProductAttributeLangEntity> ProductAttributeLang { get; set; }
        public List<PredefinedProductAttributeValueEntity> PredefinedProductAttributeValue{ get; set; }
    }
}
