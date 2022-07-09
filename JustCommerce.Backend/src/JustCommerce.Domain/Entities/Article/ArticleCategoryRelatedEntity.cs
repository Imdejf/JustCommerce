namespace JustCommerce.Domain.Entities.Article
{
    public class ArticleCategoryRelatedEntity
    {
        public Guid ArticleId { get; set; }
        public ArticleEntity Article { get; set; }
        public Guid CategoryId { get; set; }
        public ArticleCategoryEntity Category{ get; set; }
    }
}
