using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Article
{
    public static class ArticleDtoFactory
    {
        public static ArticleDTO CreateFromEntity(ArticleEntity article)
        {
            return new ArticleDTO
            {
                Id = article.Id,
                ShopId = article.ShopId,
                Slug = article.Slug,
                Active = article.Active,
                IconPath = article.IconPath,
                ArticleLang = article.ArticleLang.Select(c => ArticleLangDtoFactory.CreateFromEntity(c)).ToArray(),
                ArticleCategoryRelated = article.ArticleCategoryRelated?.Select(c => ArticleCategoryRelatedDtoFactory.CreateFromEntity(c)).ToArray(),
                ArticleRelatedProduct = article.ArticleRelatedProduct?.Select(c => ArticleRelatedProductDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
