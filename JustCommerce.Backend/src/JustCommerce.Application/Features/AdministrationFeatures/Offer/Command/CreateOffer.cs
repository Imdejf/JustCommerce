using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Offer;
using JustCommerce.Application.Common.Factories.DtoFactories.Offer;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Offer;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Features.AdministrationFeatures.Offer.Command
{
    public static class CreateOffer
    {

        public sealed record Command(Guid ShipmentMethodId, string CustomerName, string CustomerEmail, string CustomerPhone,string InvoiceRecipientName, string InvoiceRecipientTaxId,
                                     string InvoiceRecipientCountry, string InvoiceRcipientCity, string InvoiceRecipientPostalCode, string InvoiceRecipientAdress, bool DiffrentShipmentRecipient,
                                     string ShipmentRecipientName, string ShipmentRecipientCountry, string ShipmentRecipientCity, string ShipmentRecipientPostalCode, string ShipmentRecipientAdress,
                                     string AdditionalInfo, string Note, OfferStatusType OfferStatusType, string CompletionTime, string PaymentType, decimal TotallPrice, decimal ShipmentPrice, decimal ItemSumPrice,
                                     bool EInvoice, OfferSource OfferSource, DateTime SendToClientDate, List<OfferItemDTO> OfferItem,Guid ShopId) : IRequestWrapper<OfferDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, OfferDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<OfferDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var newOffer = OfferEntityFactory.CreateFromCategoryCommand(request);

                await _unitOfWorkAdministration.Offer.AddAsync(newOffer, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return OfferDtoFactory.CreateFromEntity(newOffer);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ShipmentMethodId).NotEqual(Guid.Empty);
            }
        }

    }
}
