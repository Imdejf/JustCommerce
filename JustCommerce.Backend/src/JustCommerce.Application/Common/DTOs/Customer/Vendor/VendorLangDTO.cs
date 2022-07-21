namespace JustCommerce.Application.Common.DTOs.Customer.Vendor
{
    public sealed class VendorLangDTO
    {
        public Guid VendorId { get; set; }
        public Guid LanguageId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
    }
}
