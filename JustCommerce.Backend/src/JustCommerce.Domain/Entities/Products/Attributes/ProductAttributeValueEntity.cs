using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Attributes.Common;
using JustCommerce.Domain.Entities.Products.Product;
using JustCommerce.Domain.Enums.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class ProductAttributeValueEntity : Entity 
    {
        /// <summary>
        /// Gets or sets the product attribute mapping identifier
        /// </summary>
        public Guid ProductAttributeId { get; set; }
        public ProductProductAttributeEntity ProductAttribute { get; set; } = new ProductProductAttributeEntity();
        /// <summary>
        /// Gets or sets the attribute value type identifier
        /// </summary>
        public AttributeValueType AttributeValueType { get; set; }

        /// <summary>
        /// Gets or sets the associated product identifier (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public Guid AssociatedProductId { get; set; }
        public ProductEntity AssociatedProduct { get; set; } = new ProductEntity();

        public ICollection<ProductAttributeValueLangEntity> ProductAttributeValueLang { get; set; } = new List<ProductAttributeValueLangEntity>();

        /// <summary>
        /// Gets or sets the color RGB value (used with "Color squares" attribute type)
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// Gets or sets the picture ID for image square (used with "Image squares" attribute type)
        /// </summary>
        public int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// Gets or sets the price adjustment (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "price adjustment" is specified as percentage (used only with AttributeValueType.Simple)
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the attribute value cost (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer can enter the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public bool CustomerEntersQty { get; set; }

        /// <summary>
        /// Gets or sets the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the picture (identifier) associated with this value. This picture should replace a product main picture once clicked (selected).
        /// </summary>
        public int PictureId { get; set; }
    }
}
