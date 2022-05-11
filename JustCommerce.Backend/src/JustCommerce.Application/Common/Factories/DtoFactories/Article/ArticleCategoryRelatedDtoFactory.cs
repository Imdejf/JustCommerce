using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory;
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
                ArticleCategory = ArticleCategoryDtoFactory.CreateFromEntity(entity.Category),
            };
        }
    }
}
