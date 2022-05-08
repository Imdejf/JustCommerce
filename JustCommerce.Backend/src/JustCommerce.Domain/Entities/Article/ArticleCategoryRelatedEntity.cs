using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.Article
{
    public class ArticleCategoryRelatedEntity
    {
        public Guid ArticleId { get; set; }
        public ArticleEntity Article { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }
    }
}
