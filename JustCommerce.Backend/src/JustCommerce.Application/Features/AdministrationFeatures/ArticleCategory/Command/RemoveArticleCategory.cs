using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ArticleCategory.Command
{
    public static class RemoveArticleCategory
    {

        public sealed record Command(Guid ArticleCategoryId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.ArticleCategory.ExistsAsync(request.ArticleCategoryId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Article category with Id : {request.ArticleCategoryId} doesn`t exists");
                }

                _unitOfWorkAdministration.ArticleCategory.RemoveById(request.ArticleCategoryId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
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
