namespace JustCommerce.Application.Common.DTOs.Product.Manufacturer
{
    public sealed class ManufacturerLangDTO
    {
        public Guid LanguageId { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
    }
}
