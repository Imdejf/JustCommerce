using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;
using JustCommerce.Domain.Entities.Products.Product;
using JustCommerce.Domain.Enums.Attribute;

namespace JustCommerce.Domain.Entities.Products.Attributes.Common
{
    public sealed class ProductProductAttributeEntity : Entity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = new ProductEntity();
        public Guid ProductAttributeId { get; set; }
        public ProductAttributeEntity ProductAttribute { get; set; } = new ProductAttributeEntity();

        /// <summary>
        /// Gets or sets a value a text prompt
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is required
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the attribute control type identifier
        /// </summary>
        public AttributeControlType AttributeControlType { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        //validation fields

        /// <summary>
        /// Gets or sets the validation rule for minimum length (for textbox and multiline textbox)
        /// </summary>
        public int? ValidationMinLength { get; set; }

        /// <summary>
        /// Gets or sets the validation rule for maximum length (for textbox and multiline textbox)
        /// </summary>
        public int? ValidationMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the validation rule for file allowed extensions (for file upload)
        /// </summary>
        public string ValidationFileAllowedExtensions { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the validation rule for file maximum size in kilobytes (for file upload)
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// Gets or sets the default value (for textbox and multiline textbox)
        /// </summary>
        public string DefaultValue { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets a condition (depending on other attribute) when this attribute should be enabled (visible).
        /// Leave empty (or null) to enable this attribute.
        /// Conditional attributes that only appear if a previous attribute is selected, such as having an option 
        /// for personalizing clothing with a name and only providing the text input box if the "Personalize" radio button is checked.
        /// </summary>
        public ICollection<ProductAttributeValueEntity> ConditionAttribute { get; set; }
    }
}
