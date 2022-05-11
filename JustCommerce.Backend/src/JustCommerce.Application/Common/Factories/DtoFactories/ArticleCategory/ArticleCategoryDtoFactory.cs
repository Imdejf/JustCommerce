using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory
{
    public static class ArticleCategoryDtoFactory
    {
        public static ArticleCategoryDTO CreateFromEntity(ArticleCategoryEntity articleCategory)
        {
            return new ArticleCategoryDTO
            {
                ShopId = articleCategory.ShopId,
                Slug = articleCategory.Slug,
                Active = articleCategory.Active,
                IconPath = articleCategory.IconPath,
                ArticleCategoryLang = articleCategory.ArticleCategoryLang.Select(c => ArticleCategoryLangsDtoFactory.CreateFromEntity(c)).ToArray(),
                ArticleCategoryRelated = articleCategory.ArticleCategoryRelated.Select(c => ArticleCategoryRelatedDTOFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
