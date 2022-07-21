namespace JustCommerce.Application.Common.DTOs.Product.Category
{
    public class CategoryLangDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
    }
}
