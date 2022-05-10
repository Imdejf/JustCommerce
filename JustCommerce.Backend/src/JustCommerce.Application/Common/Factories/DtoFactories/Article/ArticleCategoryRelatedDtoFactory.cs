using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Article
{
    public static class ArticleCategoryRelatedDtoFactory
    {
        public static ArticleCategoryRelatedDTO CreateFromEntity(ArticleCategoryRelatedEntity entity)
        {
            return new ArticleCategoryRelatedDTO
            {
                ArticleId = entity.ArticleId,
                CategoryId = entity.CategoryId,
            };
        }
    }
}
