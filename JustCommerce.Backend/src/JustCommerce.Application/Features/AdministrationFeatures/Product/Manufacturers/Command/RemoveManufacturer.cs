using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Manufacturers.Command
{
    public static class RemoveManufacturer
    {

        public sealed record Command(Guid ManufacturerId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.Manufacturer.ExistsAsync(request.ManufacturerId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Manufacturer with id {request.ManufacturerId} doesnt exist");
                }

                _unitOfWorkAdministration.Manufacturer.RemoveById(request.ManufacturerId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ManufacturerId).NotEqual(Guid.Empty);
            }
        }


    }
}
