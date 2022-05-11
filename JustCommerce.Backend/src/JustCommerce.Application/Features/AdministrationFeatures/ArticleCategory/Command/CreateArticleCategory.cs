using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory;
using JustCommerce.Application.Common.Factories.EntitiesFactories.ArticleCategory;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Command
{
    public static class CreateArticleCategory
    {

        public sealed record Command(Guid ShopId, string Slug, string IconPath, bool Active, List<ArticleCategoryLangDTO> ArticleCategoryLang, List<ArticleCategoryRelatedDTO> ArticleCategoryRelated) : IRequestWrapper<ArticleCategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ArticleCategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ArticleCategoryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var slugExist = await _unitOfWorkAdministration.Article.ExistSlugAsync(request.Slug, cancellationToken);

                if (slugExist)
                {
                    throw new EntityNotFoundException($"Slug exist: {request.Slug}");
                }

                var newArticleCategory = ArticleCategoryEntityFactory.CreateFromProductCommand(request);

                await _unitOfWorkAdministration.ArticleCategory.AddAsync(newArticleCategory, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return ArticleCategoryDtoFactory.CreateFromEntity(newArticleCategory);
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
