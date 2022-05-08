using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Article
{
    public sealed class ArticleEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public ICollection<ArticleLangEntity> ArticleLang { get; set; }
    }
}
