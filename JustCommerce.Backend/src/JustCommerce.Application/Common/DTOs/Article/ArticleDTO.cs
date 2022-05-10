namespace JustCommerce.Application.Common.DTOs.Article
{
    public sealed class ArticleDTO
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public Guid ShopId { get; set; }
        public ICollection<ArticleLangDTO> ArticleLang { get; set; }
        public ICollection<ArticleProductRelatedDTO>? ArticleRelatedProduct { get; set; }
        public ICollection<ArticleCategoryRelatedDTO>? ArticleCategoryRelated { get; set; }
    }
}
