namespace JustCommerce.Application.Common.DTOs.Article
{
    public sealed class ArticleLangDTO
    {
        public Guid ArticleId { get; set; }
        public Guid LanguageId { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
    }
}
