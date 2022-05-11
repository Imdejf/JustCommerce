using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory
{
    public static class ArticleCategoryLangsDtoFactory
    {
        public static ArticleCategoryLangDTO CreateFromEntity(ArticleCategoryLangEntity entity)
        {
            return new ArticleCategoryLangDTO
            {
                ArticleCategoryId = entity.ArticleCategoryId,
                LanguageId = entity.LanguageId,
                Content = entity.Content,
                MetaDescription = entity.MetaDescription,
                MetaTitle = entity.MetaTitle,
                Title = entity.Title,
            };
        }
    }
}
