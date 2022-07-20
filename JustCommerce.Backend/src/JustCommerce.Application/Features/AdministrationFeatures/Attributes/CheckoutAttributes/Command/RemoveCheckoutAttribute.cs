using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.CheckoutAttributes.Command
{
    public static class RemoveCheckoutAttribute
    {

        public sealed record Command(Guid CheckoutAttributeId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkAdministration.CheckoutAttrbiute.ExistsAsync(request.CheckoutAttributeId, cancellationToken))
                {
                    throw new EntityNotFoundException($"CheckoutAttribute with id {request.CheckoutAttributeId} doesnt exist ");
                }

                _unitOfWorkAdministration.CheckoutAttrbiute.RemoveById(request.CheckoutAttributeId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.CheckoutAttributeId).NotEqual(Guid.Empty);
            }
        }


    }
}
