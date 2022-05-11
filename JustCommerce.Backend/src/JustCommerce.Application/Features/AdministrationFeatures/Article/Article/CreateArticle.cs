using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.Factories.DtoFactories.Article;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Article;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.Article.Article
{
    public static class CreateArticle
    {

        public sealed record Command(Guid ShopId, string Slug, string IconPath, bool Active, List<ArticleLangDTO> ArticleLang, List<ArticleProductRelatedDTO> ArticleRelatedProduct, List<ArticleCategoryRelatedDTO> ArticleCategoryRelated) : IRequestWrapper<ArticleDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ArticleDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ArticleDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var slugExist = await _unitOfWorkAdministration.Article.ExistSlugAsync(request.Slug, cancellationToken);

                if(slugExist)
                {
                    throw new EntityNotFoundException($"Slug exist: {request.Slug}");
                }

                var newArticle = ArticleEntityFactory.CreateFromProductCommand(request);
                newArticle.CreatedDate = DateTime.Now;

                try
                {
                await _unitOfWorkAdministration.Article.AddAsync(newArticle, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }

                return ArticleDtoFactory.CreateFromEntity(newArticle);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
                RuleFor(c => c.Slug).NotEmpty();
            }
        }

    }
}
