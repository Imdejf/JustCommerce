using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Language;
using JustCommerce.Domain.Entities.ShipmentMethod;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Order
{
    public sealed class OrderEntity : AuditableEntity
    {
        public int OrderNumber { get; set; }
        public Guid MemberId { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerName { get; set; } = String.Empty;
        public string CustomerEmail { get; set; } = String.Empty;
        public string CustomerPhone { get; set; } = String.Empty;
        public string InvoiceRecipeintName { get; set; } = String.Empty;
        public string InvoiceRecipientTax { get; set; } = String.Empty;
        public string InvoiceRecipientCountry { get; set; } = String.Empty;
        public string InvoiceRecipientRegion { get; set; } = String.Empty;
        public string InvoiceRecipientCity { get; set; } = String.Empty;
        public string InvoiceRecipientPostalCode { get; set; } = String.Empty;
        public string InvoiceRecipientAddress { get; set; } = String.Empty;
        public bool DifferentShipmentRecipient { get; set; }
        public string ShipmentRecipientName { get; set; } = String.Empty;
        public string ShipmentRecipientCountry { get; set; } = String.Empty;
        public string ShipmentRecipientRegion { get; set; } = String.Empty;
        public string ShipmentRecipientCity { get; set; } = String.Empty;
        public string ShipmentRecipientPostalCode { get; set; } = String.Empty;
        public string ShipmentRecipientAddress { get; set; } = String.Empty;
        public decimal TotallPrice { get; set; }
        public decimal ShipmentPrice { get; set; }
        public decimal ItemsSumPrice { get; set; }
        public decimal PaymentsSum { get; set; }
        public ShipmentMethodEntity ShipmentMethod { get; set; }
        public string AdditionalInfo { get; set; } = String.Empty;
        public string InvoiceNumber { get; set; } = String.Empty;
        public string ProformaNumber { get; set; } = String.Empty;
        public bool OrderPdf { get; set; }
        public bool Paid { get; set; }
        public bool Invoice { get; set; }
        public string Note { get; set; } = String.Empty;
        public LanguageEntity LanguageVersion { get; set; }
        public bool NewsletterAcceptation { get; set; }
        public bool StatueAcceptation { get; set; }
        public bool DataProcessingAcceptation { get; set; }
        public int PaymentType { get; set; }
        public bool FastInvoice { get; set; }
        public bool PaymentCallSent { get; set; }
        public bool IncludeShipmentRecipientOnInvoice { get; set; }
        public string InvoiceEmail { get; set; } = String.Empty;
        public int TradeCreditDays { get; set; }
        public bool PaymentReminderSend { get; set; }
        public OrderSource Source { get; set; }
        public int Rated  { get; set; }

    }
}
