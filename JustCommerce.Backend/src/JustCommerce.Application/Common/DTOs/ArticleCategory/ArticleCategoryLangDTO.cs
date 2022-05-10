namespace JustCommerce.Application.Common.DTOs.ArticleCategory
{
    public class ArticleCategoryLangDTO
    {
        public Guid LanguageId { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }
    }
}
