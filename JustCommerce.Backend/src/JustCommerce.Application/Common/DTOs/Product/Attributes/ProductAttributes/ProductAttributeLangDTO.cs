namespace JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes
{
    public sealed class ProductAttributeLangDTO
    {
        public Guid ProductAttributeId { get; set; }
        public Guid LanguageId { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;
    }
}
