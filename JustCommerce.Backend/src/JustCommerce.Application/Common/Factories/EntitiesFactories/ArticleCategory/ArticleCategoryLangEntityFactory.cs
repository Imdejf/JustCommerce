using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Domain.Entities.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.ArticleCategory
{
    public static class ArticleCategoryLangEntityFactory
    {
        public static ArticleCategoryLangEntity CreateFromDto(ArticleCategoryLangDTO articleLang)
        {
            return new ArticleCategoryLangEntity
            {
                ArticleCategoryId = articleLang.ArticleCategoryId,
                MetaTitle = articleLang.MetaTitle,
                MetaDescription = articleLang.MetaDescription,
                Content = articleLang.Content,
                LanguageId = articleLang.LanguageId,
                Title = articleLang.Title,
            };
        }
    }
}
