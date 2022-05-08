using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleCategoryEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public ICollection<ArticleCategoryLangEntity> ArticleCategoryLang { get; set; }
    }
}
