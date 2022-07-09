using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleCategoryEntity : Entity
    {
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public Guid ShopId { get; set; }
        public StoreEntity Shop { get; set; }
        public ICollection<ArticleCategoryLangEntity> ArticleCategoryLang { get; set; }
        public ICollection<ArticleCategoryRelatedEntity>? ArticleCategoryRelated { get; set; }
    }
}
