using JustCommerce.Application.Common.DTOs.Article;

namespace JustCommerce.Application.Common.DTOs.ArticleCategory
{
    public class ArticleCategoryDTO
    {
        public string Slug { get; set; }
        public string IconPath { get; set; }
        public bool Active { get; set; }
        public Guid ShopId { get; set; }
        public ICollection<ArticleCategoryLangDTO>? ArticleCategoryLang { get; set; }
        public ICollection<ArticleCategoryRelatedDTO>? ArticleCategoryRelated { get; set; }
    }
}
