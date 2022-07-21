namespace JustCommerce.Application.Common.DTOs.Product.Product
{
    public sealed class ProductLangDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public Guid LanguageId { get; set; }
    }
}
