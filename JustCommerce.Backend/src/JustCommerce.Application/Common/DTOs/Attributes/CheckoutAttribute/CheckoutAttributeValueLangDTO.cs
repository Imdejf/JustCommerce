namespace JustCommerce.Application.Common.DTOs.Attributes.CheckoutAttribute
{
    public sealed class CheckoutAttributeValueLangDTO
    {
        public Guid CheckoutAttributeValueId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
