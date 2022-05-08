using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleLangEntity
    {
        public Guid ArticleId { get; set; }
        public ArticleEntity Article { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
    }
}
