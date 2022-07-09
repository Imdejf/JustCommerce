namespace JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes
{
    public sealed class ProductAttributeValueLangDTO
    {
        public Guid ProductAttributeValueId { get; set; }
        public Guid LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; } = String.Empty;
    }
}
