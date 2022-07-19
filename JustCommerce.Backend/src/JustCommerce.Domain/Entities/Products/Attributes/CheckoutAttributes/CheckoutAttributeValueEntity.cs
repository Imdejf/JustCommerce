using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes
{
    public sealed class CheckoutAttributeValueEntity : Entity
    {
        /// <summary>
        /// Gets or sets the checkout attribute mapping identifier
        /// </summary>
        public Guid CheckoutAttributeId { get; set; }
        public CheckoutAttributeEntity CheckoutAttribute { get; set; }
        /// <summary>
        /// Gets or sets the checkout attribute name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the color RGB value (used with "Color squares" attribute type)
        /// </summary>
        public string ColorSquaresRgb { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price adjustment
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        public List<CheckoutAttributeValueLangEntity> CheckoutAttributeValueLang { get; set; }
    }
}
