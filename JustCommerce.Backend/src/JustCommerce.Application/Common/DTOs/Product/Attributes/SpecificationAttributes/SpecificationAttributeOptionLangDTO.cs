namespace JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes
{
    public sealed class SpecificationAttributeOptionLangDTO
    {
        public Guid SpecificationAttributeOptionId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
