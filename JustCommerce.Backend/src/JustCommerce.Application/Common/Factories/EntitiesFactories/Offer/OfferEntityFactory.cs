using JustCommerce.Application.Features.AdministrationFeatures.Offer.Command;
using JustCommerce.Domain.Entities.Offer;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Offer
{
    public static class OfferEntityFactory
    {
        public static OfferEntity CreateFromCategoryCommand(CreateOffer.Command command)
        {
            return new OfferEntity
            {
                InvoiceRecipientTaxId = command.InvoiceRecipientTaxId,
                DiffrentShipmentRecipient = command.DiffrentShipmentRecipient,
                SendToClientDate = command.SendToClientDate,
                AdditionalInfo = command.AdditionalInfo,
                ShipmentMethodId = command.ShipmentMethodId,
                ShipmentPrice = command.ShipmentPrice,
                ShipmentRecipientAdress = command.ShipmentRecipientAdress,
                ShipmentRecipientCity = command.ShipmentRecipientCity,
                ShipmentRecipientCountry = command.ShipmentRecipientCountry,
                CompletionTime = command.CompletionTime,
                ItemSumPrice = command.ItemSumPrice,
                OfferSource = command.OfferSource,
                OfferStatusType = command.OfferStatusType,
                CustomerEmail = command.CustomerEmail,
                CustomerName = command.CustomerName,
                EInvoice = command.EInvoice,
                InvoiceRcipientCity = command.InvoiceRcipientCity,
                InvoiceRecipientAdress = command.InvoiceRecipientAdress,
                InvoiceRecipientCountry = command.InvoiceRecipientCountry,
                InvoiceRecipientName = command.InvoiceRecipientName,
                InvoiceRecipientPostalCode = command.InvoiceRecipientPostalCode,
                Note = command.Note,
                ShipmentRecipientPostalCode = command.ShipmentRecipientPostalCode,
                ShipmentRecipientName = command.ShipmentRecipientName,
                TotallPrice = command.TotallPrice,
                PaymentType = command.PaymentType,
                ShopId = command.ShopId,
                OfferItem = command.OfferItem?.Select(c => new OfferItemEntity
                {
                    OfferId = c.OfferId,
                    Offer = null,
                    ProductSellableId = c.ProductSellableId,
                    ProductSellable = null
                }).ToArray()
            };
        }
    }
}
