using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Attributes.Common;

namespace JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute
{
    public sealed class SpecificationAttributeOptionEntity : Entity
    {
        /// <summary>
        /// Gets or sets the specification attribute identifier
        /// </summary>
        public Guid SpecificationAttributeId { get; set; }
        public SpecificationAttributeEntity SpecificationAttribute { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color RGB value (used when you want to display "Color squares" instead of text)
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        public ICollection<SpecificationAttributeOptionLangEntity> SpecificationAttributeOptionLang { get; set; }
        public ICollection<ProductSpecificationAttributeEntity> ProductSpecificationAttribute { get; set; }
    }
}
