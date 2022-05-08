using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.Article
{
    public class ArticleRelatedProduct
    {
        public Guid ArticleId { get; set; }
        public ArticleEntity Article { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }
    }
}
