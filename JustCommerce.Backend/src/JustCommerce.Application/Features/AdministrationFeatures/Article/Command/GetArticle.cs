using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.Factories.DtoFactories.Article;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.AdministrationFeatures.Article.Command
{
    public static class GetArticle
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<ArticleDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<ArticleDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<ArticleDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var articleList = await _unitOfWorkAdministration.Article.GetAllByShopIdAsync(request.ShopId, cancellationToken);

                return articleList.Select(c => ArticleDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
