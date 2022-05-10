using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Domain.Entities.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Article
{
    public static class ArticleLangEntityFactory
    {
        public static ArticleLangEntity CreateFromDto(ArticleLangDTO articleLang)
        {
            return new ArticleLangEntity
            {
                ArticleId = articleLang.ArticleId,
                LanguageId = articleLang.LanguageId,
                Description = articleLang.Description,
                ShortContent = articleLang.ShortContent,
                Content = articleLang.Content,
                KeyWords = articleLang.KeyWords,
                MetaDescription = articleLang.MetaDescription,
                Title = articleLang.Title,
            };
        }

        public static ArticleLangEntity CreateFromData(Guid articleId, Guid languageId, string description, string content, string shortContent, string keyWords, string metaDescription, string title)
        {
            return new ArticleLangEntity
            {
                ArticleId = articleId,
                LanguageId = languageId,
                Description = description,
                Content = content,
                ShortContent = shortContent,
                KeyWords = keyWords,
                MetaDescription = metaDescription,
                Title = title,
            };
        }
    }
}
