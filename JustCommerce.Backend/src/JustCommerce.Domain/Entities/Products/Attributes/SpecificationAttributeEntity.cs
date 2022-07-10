using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class SpecificationAttributeEntity : Entity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute group identifier
        /// </summary>
        public Guid SpecificationAttributeGroupId { get; set; }
        public SpecificationAttributeGroupEntity SpecificationAttributeGroup { get; set; }
        public List<SpecificationAttributeOptionEntity> SpecificationAttributeOption { get; set; }
    }
}
