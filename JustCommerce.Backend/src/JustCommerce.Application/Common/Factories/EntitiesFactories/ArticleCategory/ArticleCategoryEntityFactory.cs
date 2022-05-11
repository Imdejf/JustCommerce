using JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Command;
using JustCommerce.Domain.Entities.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.ArticleCategory
{
    public static class ArticleCategoryEntityFactory
    {
        public static ArticleCategoryEntity CreateFromProductCommand(CreateArticleCategory.Command command)
        {
            return new ArticleCategoryEntity
            {
                ShopId = command.ShopId,
                Slug = command.Slug,
                Active = command.Active,
                IconPath = command.IconPath,
                ArticleCategoryLang = command.ArticleCategoryLang.Select(c => ArticleCategoryLangEntityFactory.CreateFromDto(c)).ToArray(),
                ArticleCategoryRelated = command.ArticleCategoryRelated.Select(c => new ArticleCategoryRelatedEntity
                {
                    Category = null,
                    CategoryId = c.CategoryId,
                    Article = null,
                    ArticleId = Guid.Empty
                    
                }).ToArray()
            };
        }
    }
}
