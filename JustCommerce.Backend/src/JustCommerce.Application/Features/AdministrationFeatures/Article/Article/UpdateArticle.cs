using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.Factories.DtoFactories.Article;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Article;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Article;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.Article.Article
{
    public static class UpdateArticle
    {

        public sealed record Command(Guid ArticleId, string Slug, string IconPath, bool Active, List<ArticleLangDTO> ArticleLang, List<ArticleProductRelatedDTO> ArticleProductRelated,
                                     List<ArticleCategoryRelatedDTO> ArticleCategoryRelated) : IRequestWrapper<ArticleDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ArticleDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ArticleDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = await _unitOfWorkAdministration.Article.GetFullArticleAsync(request.ArticleId);

                if (article is null)
                {
                    throw new EntityNotFoundException($"Article with Id : {request.ArticleId} doesn`t exists");
                }

                article.Slug = request.Slug;
                article.IconPath = request.IconPath;
                article.Active = request.Active;


                foreach (var lang in article.ArticleLang)
                {
                    var newLang = request.ArticleLang.Where(c => c.LanguageId == lang.Language.Id).FirstOrDefault();
                    if (newLang != null)
                    {
                        lang.KeyWords = newLang.KeyWords;
                        lang.Title = newLang.Title;
                        lang.ShortContent = newLang.ShortContent;
                        lang.Content = newLang.Content;
                        lang.Description = newLang.Description;
                        lang.MetaDescription = newLang.MetaDescription;
                    }
                    else
                    {
                        var addLang = ArticleLangEntityFactory.CreateFromDto(newLang);
                        article.ArticleLang.Add(addLang);
                    }
                }

                var articleProductList = request.ArticleProductRelated.Select(c => new ArticleRelatedProductEntity { ArticleId = c.ArticleId, ProductId = c.ProductId }).ToList();
                article.ArticleRelatedProduct?.ToList().AddRange(article.ArticleRelatedProduct = articleProductList.Where(c => !article.ArticleRelatedProduct.Contains(c)).ToList());

                var articleCategoryList = request.ArticleCategoryRelated.Select(c => new ArticleCategoryRelatedEntity { ArticleId = c.ArticleId, CategoryId = c.CategoryId }).ToList();
                article.ArticleCategoryRelated?.ToList().AddRange(article.ArticleCategoryRelated = articleCategoryList.Where(c => !article.ArticleCategoryRelated.Contains(c)).ToList());

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return ArticleDtoFactory.CreateFromEntity(article);

            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }

    }
}
