using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command
{
    public static class UpdateProductType
    {
        public sealed record Command(Guid ProductTypeId,string Name) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var productType = await _unitOfWorkAdministration.ProductType.GetByIdAsync(request.ProductTypeId, cancellationToken);

                if(productType is null)
                {
                    throw new EntityNotFoundException($"Update ProductType Id:{request.ProductTypeId}");
                }

                productType.Name = request.Name;

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTypeId).NotEqual(Guid.Empty);
                RuleFor(c => c.Name).NotEmpty();
            }
        }
    }
}
