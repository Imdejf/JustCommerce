using JustCommerce.Application.Common.DTOs.Order;
using JustCommerce.Domain.Entities.Order;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Order
{
    public static class OrderDtoFactory
    {
        public static OrderDTO CreateFromEntity(OrderEntity order)
        {
            return new OrderDTO
            {
                ShopId = order.ShopId,
                ShipmentMethodId = order.ShipmentMethodId,
                ShipmentPrice = order.ShipmentPrice,
                ShipmentRecipientAddress = order.ShipmentRecipientAddress,
                ShipmentRecipientCity = order.ShipmentRecipientCity,
                ShipmentRecipientCountry = order.ShipmentRecipientCountry,
                ShipmentRecipientName = order.ShipmentRecipientName,
                ShipmentRecipientPostalCode = order.ShipmentRecipientPostalCode,
                ShipmentRecipientRegion = order.ShipmentRecipientRegion,
                Source = order.Source,
                StatueAcceptation = order.StatueAcceptation,
                Status = order.Status,
                DifferentShipmentRecipient = order.DifferentShipmentRecipient,
                IncludeShipmentRecipientOnInvoice = order.IncludeShipmentRecipientOnInvoice,
                ItemsSumPriceGross = order.ItemsSumPriceGross,
                PaymentCallSent = order.PaymentCallSent,
                PaymentReminderSend = order.PaymentReminderSend,
                PaymentsSum = order.PaymentsSum,
                AdditionalInfo = order.AdditionalInfo,
                CustomerEmail = order.CustomerEmail,
                CustomerName = order.CustomerName,
                CustomerPhone = order.CustomerPhone,
                DataProcessingAcceptation = order.DataProcessingAcceptation,
                FastInvoice = order.FastInvoice,
                Invoice = order.Invoice,
                InvoiceEmail = order.InvoiceEmail,
                InvoiceNumber = order.InvoiceNumber,
                InvoiceRecipeintName = order.InvoiceRecipeintName,
                InvoiceRecipientAddress = order.InvoiceRecipientAddress,
                InvoiceRecipientCity = order.InvoiceRecipientCity,
                InvoiceRecipientCountry = order.InvoiceRecipientCountry,
                InvoiceRecipientPostalCode = order.InvoiceRecipientPostalCode,
                InvoiceRecipientRegion = order.InvoiceRecipientRegion,
                InvoiceRecipientTax = order.InvoiceRecipientTax,
                LanguageVersionId = order.LanguageVersionId,
                MemberId = order.MemberId,
                NewsletterAcceptation = order.NewsletterAcceptation,
                Note = order.Note,
                OrderNumber = order.OrderNumber,
                OrderPdf = order.OrderPdf,
                Paid = order.Paid,
                PaymentType = order.PaymentType,
                ProformaNumber = order.ProformaNumber,
                Rated = order.Rated,
                TotallPriceGross = order.TotallPriceGross,
                TradeCreditDays = order.TradeCreditDays,
            };
        }
    }
}
