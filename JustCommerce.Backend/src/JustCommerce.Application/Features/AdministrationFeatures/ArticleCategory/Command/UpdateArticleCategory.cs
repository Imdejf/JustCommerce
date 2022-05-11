using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory;
using JustCommerce.Application.Common.Factories.EntitiesFactories.ArticleCategory;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Command
{
    public static class UpdateArticleCategory
    {

        public sealed record Command(Guid ArticleCategoryId, string Slug, string IconPath, bool Active, List<ArticleCategoryLangDTO> ArticleCategoryLang) : IRequestWrapper<ArticleCategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ArticleCategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ArticleCategoryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var articleCategory = await _unitOfWorkAdministration.ArticleCategory.GetByIdAsync(request.ArticleCategoryId, cancellationToken);

                if(articleCategory is null)
                {
                    throw new EntityNotFoundException($"Slug exist: {request.Slug}");
                }

                articleCategory.Slug = request.Slug;
                articleCategory.Active = request.Active;
                articleCategory.IconPath = request.IconPath;

                foreach (var lang in articleCategory.ArticleCategoryLang)
                {
                    var newLang = request.ArticleCategoryLang.Where(c => c.LanguageId == lang.Language.Id).FirstOrDefault();
                    if (newLang != null)
                    {
                        lang.Title = newLang.Title;
                        lang.MetaDescription = newLang.MetaDescription;
                        lang.MetaTitle = newLang.MetaTitle;
                        lang.Content = newLang.Content;
                    }
                    else
                    {
                        var addLang = ArticleCategoryLangEntityFactory.CreateFromDto(newLang);
                        articleCategory.ArticleCategoryLang.Add(addLang);
                    }
                }

                return ArticleCategoryDtoFactory.CreateFromEntity(articleCategory);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ArticleCategoryId).NotEqual(Guid.Empty);
            }
        }

    }
}
