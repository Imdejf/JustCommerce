using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes
{
    public sealed class CheckoutAttributeValueLangEntity
    {
        public Guid CheckoutAttributeValueId { get; set; }
        public CheckoutAttributeValueEntity CheckoutAttributeValue { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Name { get; set; }
    }
}
