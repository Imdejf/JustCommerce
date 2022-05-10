using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Article
{
    public static class ArticleRelatedProductDtoFactory
    {
        public static ArticleProductRelatedDTO CreateFromEntity(ArticleRelatedProductEntity entity)
        {
            return new ArticleProductRelatedDTO
            {
                ArticleId = entity.ArticleId,
                ProductId = entity.ProductId,
            };
        }
    }
}
