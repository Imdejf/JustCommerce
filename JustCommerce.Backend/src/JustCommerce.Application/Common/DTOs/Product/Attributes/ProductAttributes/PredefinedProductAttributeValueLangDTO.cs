namespace JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes

{
    public sealed class PredefinedProductAttributeValueLangDTO
    {
        public Guid PredefinedProductAttributeValueId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
