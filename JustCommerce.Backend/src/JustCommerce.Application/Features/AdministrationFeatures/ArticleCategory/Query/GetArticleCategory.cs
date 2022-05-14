using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory;
using JustCommerce.Application.Common.Interfaces;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Query
{
    public static class GetArticleCategory
    {

        public sealed record Query(Guid ShopId, Guid DefualtLanguageId) : IRequestWrapper<List<ArticleCategoryDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<ArticleCategoryDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<ArticleCategoryDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var articleCategoryList = await _unitOfWorkAdministration.ArticleCategory.GetAllByShopIdAsync(request.ShopId, cancellationToken);

                return articleCategoryList.Select(c => ArticleCategoryDtoFactory.CreateFromEntity(c)).ToList();

            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
                RuleFor(c => c.DefualtLanguageId).NotEqual(Guid.Empty);
            }
        }

    }
}
