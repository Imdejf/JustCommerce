using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.ProductTags.Command
{
    public static class RemoveProductTag
    {

        public sealed record Command(Guid ProductTagId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.ProductTag.ExistsAsync(request.ProductTagId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Product tag with id {request.ProductTagId} doesnt exist");
                }

                _unitOfWorkAdministration.ProductTag.RemoveById(request.ProductTagId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTagId).NotEqual(Guid.Empty);
            }
        }


    }
}
