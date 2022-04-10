using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command
{
    public static class RemoveProductType
    {
        public sealed record Command(Guid ProductTypeId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var exist = await _unitOfWorkAdministration.ProductType.GetByIdAsync(request.ProductTypeId);

                if(exist is null)
                {
                    throw new EntityNotFoundException($"ProductType Id: {request.ProductTypeId}");
                }

                _unitOfWorkAdministration.ProductType.Remove(exist);

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTypeId).NotEqual(Guid.Empty);
            }
        }
    }
}
