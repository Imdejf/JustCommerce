using JustCommerce.Application.Common.DTOs.ArticleCategory;

namespace JustCommerce.Application.Common.DTOs.Article
{
    public class ArticleCategoryRelatedDTO
    {
        public Guid ArticleId { get; set; }
        public ArticleDTO Article { get; set; }
        public Guid CategoryId { get; set; }
        public ArticleCategoryDTO ArticleCategory { get; set; }
    }
}
