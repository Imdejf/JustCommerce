namespace JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes
{
    public class PredefinedProductAttributeValueDTO
    {
        public Guid Id { get; set; }
        public Guid ProductAttributeId { get; set; }
        public List<PredefinedProductAttributeValueLangDTO> PredefinedProductAttributeValueLang { get; set; } = new List<PredefinedProductAttributeValueLangDTO>();
        public string Name { get; set; } = string.Empty;
        public decimal PriceAdjustment { get; set; }
        public bool PriceAdjustmentUsePercentage { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal Cost { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
    }
}