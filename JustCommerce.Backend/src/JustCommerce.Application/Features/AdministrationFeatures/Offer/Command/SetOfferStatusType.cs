using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Offer.Command
{
    public static class SetOfferStatusType
    {

        public sealed record Command(Guid OfferId, OfferStatusType OfferStatusType) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkAdministration.Offer.ExistsAsync(request.OfferId))
                {
                    throw new EntityNotFoundException($"Offer with Id : {request.OfferId} doesn`t exists");
                }

                _unitOfWorkAdministration.Offer.SetStatusType(request.OfferId, request.OfferStatusType);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.OfferId).NotEqual(Guid.Empty);
                RuleFor(c => c.OfferStatusType).IsInEnum();
            }
        }

    }
}
