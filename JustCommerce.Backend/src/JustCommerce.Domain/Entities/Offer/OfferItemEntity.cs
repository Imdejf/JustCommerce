namespace JustCommerce.Domain.Entities.Offer
{
    public sealed class OfferItemEntity
    {
        public Guid OfferId { get; set; }
        public OfferEntity Offer { get; set; }
        public Guid ProductSellableId { get; set; }
        public int Quantity { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal ProducentPrice { get; set; }
    }
}
