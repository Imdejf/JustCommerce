using JustCommerce.Application.Common.Factories.DtoFactories.Article;
using JustCommerce.Application.Features.AdministrationFeatures.Article.Article;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Article
{
    public class ArticleEntityFactory
    {
        public static ArticleEntity CreateFromProductCommand(CreateArticle.Command command)
        {
            return new ArticleEntity
            {
                ShopId = command.ShopId,
                Active = command.Active,
                Slug = command.Slug,
                IconPath = command.IconPath,
                ArticleLang = command.ArticleLang.Select(c => ArticleLangEntityFactory.CreateFromDto(c)).ToArray(),
                ArticleCategoryRelated = command.ArticleCategoryRelated?.Select(c => new ArticleCategoryRelatedEntity
                {
                    Category = null,
                    CategoryId = c.CategoryId,
                    Article = null,
                    ArticleId = Guid.Empty
                }).ToArray(),
                ArticleRelatedProduct = command.ArticleRelatedProduct?.Select(c => new ArticleRelatedProductEntity
                {
                    Product = null,
                    ProductId = c.ProductId,
                    Article = null,
                    ArticleId = Guid.Empty
                }).ToArray(),
            };
        }
    }
}
