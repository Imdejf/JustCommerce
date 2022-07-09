using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    /// <summary>
    /// Represents a predefined (default) product attribute value
    /// </summary>
    public sealed class PredefinedProductAttributeValueEntity : Entity
    {
        public Guid ProductAttributeId { get; set; }
        public ProductAttributeEntity ProductAttribute { get; set; } = new ProductAttributeEntity();
        public List<PredefinedProductAttributeValueLangEntity> PredefinedProductAttributeValueLang { get; set; } = new List<PredefinedProductAttributeValueLangEntity>();

        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price adjustment
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "price adjustment" is specified as percentage
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the attribute value cost
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}