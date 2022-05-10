using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public ICollection<ArticleLangEntity> ArticleLang { get; set; }
        public ICollection<ArticleRelatedProductEntity>? ArticleRelatedProduct { get; set; }
        public ICollection<ArticleCategoryRelatedEntity>? ArticleCategoryRelated { get; set; }
    }
}
