using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.Article
{
    public class ArticleRelatedProductEntity
    {
        public Guid ArticleId { get; set; }
        public ArticleEntity Article { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
