using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.ArticleCategory;
using JustCommerce.Application.Common.Factories.DtoFactories.ArticleCategory;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Query
{
    public static class GetArticleCategoryById
    {

        public sealed record Query(Guid ArticleCategoryId) : IRequestWrapper<ArticleCategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ArticleCategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ArticleCategoryDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var articleCategory = await _unitOfWorkAdministration.ArticleCategory.GetByIdAsync(request.ArticleCategoryId, cancellationToken);

                return ArticleCategoryDtoFactory.CreateFromEntity(articleCategory);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ArticleCategoryId).NotEqual(Guid.Empty);
            }
        }

    }
}
