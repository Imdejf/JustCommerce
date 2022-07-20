namespace JustCommerce.Application.Common.DTOs.Product.Attributes.CheckoutAttribute
{
    public sealed class CheckoutAttributeValueDTO
    {
        public Guid Id { get; set; }
        public Guid CheckoutAttributeId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ColorSquaresRgb { get; set; } = String.Empty;
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public List<CheckoutAttributeValueLangDTO> CheckoutAttributeValueLang { get; set; }
    }
}
