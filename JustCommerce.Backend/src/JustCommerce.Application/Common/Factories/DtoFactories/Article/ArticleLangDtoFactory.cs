using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Article
{
    public static class ArticleLangDtoFactory
    {
        public static ArticleLangDTO CreateFromEntity(ArticleLangEntity entity)
        {
            return new ArticleLangDTO
            {
                ShortContent = entity.ShortContent,
                ArticleId = entity.ArticleId,
                Content = entity.Content,
                Description = entity.Description,
                KeyWords = entity.KeyWords,
                LanguageId = entity.LanguageId,
                MetaDescription = entity.MetaDescription,
                Title = entity.Title,
            };
        }
    }
}
