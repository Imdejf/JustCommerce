using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.ShipmentMethod;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Offer
{
    public sealed class OfferEntity : AuditableEntity
    {
        public Guid ShipmentMethodId { get; set; }
        public ShipmentMethodEntity ShipmentMethod { get; set; }
        public int OfferNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string InvoiceRecipientName { get; set; }
        public string InvoiceRecipientTaxId { get; set; }
        public string InvoiceRecipientCountry { get; set; }
        public string InvoiceRcipientCity { get; set; }
        public string InvoiceRecipientPostalCode { get; set; }
        public string InvoiceRecipientAdress { get; set; }
        public bool DiffrentShipmentRecipient { get; set; }
        public string? ShipmentRecipientName { get; set; }
        public string ShipmentRecipientCountry { get; set; }
        public string ShipmentRecipientCity { get; set; }
        public string ShipmentRecipientPostalCode { get; set; }
        public string ShipmentRecipientAdress { get; set; }
        public string AdditionalInfo { get; set; }
        public string Note { get; set; }
        public OfferStatusType OfferStatusType { get; set; }
        public string CompletionTime { get; set; }
        public string PaymentType { get; set; }
        public decimal TotallPrice { get; set; }
        public decimal ShipmentPrice { get; set; }
        public decimal ItemSumPrice { get; set; }
        public bool EInvoice { get; set; }
        public OfferSource OfferSource { get; set; }
        public DateTime? SendToClientDate { get; set; }
        public ICollection<OfferItemEntity>? OfferItem { get; set; }
    }
}
