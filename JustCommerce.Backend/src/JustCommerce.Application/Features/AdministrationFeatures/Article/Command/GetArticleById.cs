using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Article;
using JustCommerce.Application.Common.Factories.DtoFactories.Article;
using JustCommerce.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.Article.Command
{
    public static class GetArticleById
    {

        public sealed record Query(Guid ArticleId) : IRequestWrapper<ArticleDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ArticleDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ArticleDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var article = await _unitOfWorkAdministration.Article.GetFullArticleAsync(request.ArticleId);

                return ArticleDtoFactory.CreateFromEntity(article);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ArticleId).NotEqual(Guid.Empty);
            }
        }

    }
}
