using JustCommerce.Application.Common.DTOs.Offer;
using JustCommerce.Domain.Entities.Offer;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Offer
{
    public static class OfferDtoFactory
    {
        public static OfferDTO CreateFromEntity(OfferEntity offer)
        {
            return new OfferDTO
            {
                InvoiceRecipientTaxId = offer.InvoiceRecipientTaxId,
                DiffrentShipmentRecipient = offer.DiffrentShipmentRecipient,
                SendToClientDate = offer.SendToClientDate,
                AdditionalInfo = offer.AdditionalInfo,
                ShipmentMethodId = offer.ShipmentMethodId,
                ShipmentPrice = offer.ShipmentPrice,
                ShipmentRecipientAdress = offer.ShipmentRecipientAdress,
                ShipmentRecipientCity = offer.ShipmentRecipientCity,
                ShipmentRecipientCountry = offer.ShipmentRecipientCountry,
                CompletionTime = offer.CompletionTime,
                ItemSumPrice = offer.ItemSumPrice,
                OfferSource = offer.OfferSource,
                OfferStatusType = offer.OfferStatusType,
                CustomerEmail = offer.CustomerEmail,
                CustomerName = offer.CustomerName,
                EInvoice = offer.EInvoice,
                InvoiceRcipientCity = offer.InvoiceRcipientCity,
                InvoiceRecipientAdress = offer.InvoiceRecipientAdress,
                InvoiceRecipientCountry = offer.InvoiceRecipientCountry,
                InvoiceRecipientName = offer.InvoiceRecipientName,
                InvoiceRecipientPostalCode = offer.InvoiceRecipientPostalCode,
                Note = offer.Note,
                ShipmentRecipientPostalCode = offer.ShipmentRecipientPostalCode,
                ShipmentRecipientName = offer.ShipmentRecipientName,
                TotallPrice = offer.TotallPrice,
                PaymentType = offer.PaymentType,
                ShopId = offer.ShopId,
                OfferItem = offer.OfferItem?.Select(c => OfferItemDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
