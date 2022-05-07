using JustCommerce.Application.Common.DTOs.Product;

namespace JustCommerce.Application.Common.DTOs.Offer
{
    public class OfferItemDTO
    {
        public Guid OfferId { get; set; }
        public Guid ProductSellableId { get; set; }
        public int Quantity { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal ProducentPrice { get; set; }
    }
}
