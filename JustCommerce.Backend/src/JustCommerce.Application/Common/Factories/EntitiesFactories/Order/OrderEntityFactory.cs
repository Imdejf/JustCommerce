using JustCommerce.Application.Features.AdministrationFeatures.Order.Command;
using JustCommerce.Domain.Entities.Order;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.command
{
    public static class OrderEntityFactory
    {
        public static OrderEntity CreateFromCommand(CreateOrder.Command command)
        {
            return new OrderEntity
            {
                ShopId = command.ShopId,
                ShipmentMethodId = command.ShipmentMethodId,
                ShipmentPrice = command.ShipmentPrice,
                ShipmentRecipientAddress = command.ShipmentRecipientAddress,
                ShipmentRecipientCity = command.ShipmentRecipientCity,
                ShipmentRecipientCountry = command.ShipmentRecipientCountry,
                ShipmentRecipientName = command.ShipmentRecipientName,
                ShipmentRecipientPostalCode = command.ShipmentRecipientPostalCode,
                ShipmentRecipientRegion = command.ShipmentRecipientRegion,
                Source = command.Source,
                StatueAcceptation = command.StatueAcceptation,
                Status = command.Status,
                DifferentShipmentRecipient = command.DifferentShipmentRecipient,
                IncludeShipmentRecipientOnInvoice = command.IncludeShipmentRecipientOnInvoice,
                ItemsSumPriceGross = command.ItemsSumPriceGross,
                PaymentCallSent = command.PaymentCallSent,
                PaymentReminderSend = command.PaymentReminderSend,
                PaymentsSum = command.PaymentsSum,
                AdditionalInfo = command.AdditionalInfo,
                CustomerEmail = command.CustomerEmail,
                CustomerName = command.CustomerName,
                CustomerPhone = command.CustomerPhone,
                DataProcessingAcceptation = command.DataProcessingAcceptation,
                FastInvoice = command.FastInvoice,
                Invoice = command.Invoice,
                InvoiceEmail = command.InvoiceEmail,
                InvoiceNumber = command.InvoiceNumber,
                InvoiceRecipeintName = command.InvoiceRecipeintName,
                InvoiceRecipientAddress = command.InvoiceRecipientAddress,
                InvoiceRecipientCity = command.InvoiceRecipientCity,
                InvoiceRecipientCountry = command.InvoiceRecipientCountry,
                InvoiceRecipientPostalCode = command.InvoiceRecipientPostalCode,
                InvoiceRecipientRegion = command.InvoiceRecipientRegion,
                InvoiceRecipientTax = command.InvoiceRecipientTax,
                LanguageVersionId = command.LanguageVersionId,
                MemberId = command.MemberId,
                NewsletterAcceptation = command.NewsletterAcceptation,
                Note = command.Note,
                OrderPdf = command.OrderPdf,
                Paid = command.Paid,
                PaymentType = command.PaymentType,
                Rated = command.Rated,
                TotallPriceGross = command.TotallPriceGross,
                TradeCreditDays = command.TradeCreditDays,
            };
        }
    }
}
