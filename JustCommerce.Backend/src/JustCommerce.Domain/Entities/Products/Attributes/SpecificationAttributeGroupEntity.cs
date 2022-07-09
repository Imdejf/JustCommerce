using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class SpecificationAttributeGroupEntity : Entity
    {
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public ICollection<SpecificationAttributeEntity> SpecificationAttribute { get; set; }
    }
}
