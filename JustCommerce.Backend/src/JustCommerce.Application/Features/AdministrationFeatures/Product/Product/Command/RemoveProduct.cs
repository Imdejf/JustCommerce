using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Product.Command
{
    public static class RemoveProduct
    {

        public sealed record Command(Guid ProductId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.Product.ExistsAsync(request.ProductId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Product with id {request.ProductId} doesnt exist");
                }

                _unitOfWorkAdministration.Product.RemoveById(request.ProductId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductId).NotEqual(Guid.Empty);
            }
        }


    }
}
