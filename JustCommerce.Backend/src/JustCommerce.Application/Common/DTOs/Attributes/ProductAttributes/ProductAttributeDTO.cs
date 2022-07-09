namespace JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes
{
    public sealed class ProductAttributeDTO
    {
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Guid StoreId { get; set; }
        public List<ProductAttributeLangDTO> ProductAttributeLang { get; set; } = new List<ProductAttributeLangDTO>();
        public List<PredefinedProductAttributeValueDTO> PredefinedProductAttributeValue { get; set; } = new List<PredefinedProductAttributeValueDTO>();
    }
}
