using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleCategoryLangEntity
    {
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public ArticleCategoryEntity ArticleCategory { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }
    }
}
