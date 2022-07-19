using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute
{
    public sealed class ProductAttributeValueLangEntity
    {
        public Guid ProductAttributeValueId { get; set; }
        public ProductAttributeValueEntity ProductAttributeValue { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
