using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using JustCommerce.Domain.Entities.Products.Product;
using JustCommerce.Domain.Enums.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.Products.Attributes.Common
{
    public sealed class ProductSpecificationAttributeEntity : Entity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        /// <summary>
        /// Gets or sets the attribute type ID
        /// </summary>
        public SpecificationAttributeType SpecificationAttributeType { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute identifier
        /// </summary>
        public Guid SpecificationAttributeOptionId { get; set; }
        public SpecificationAttributeOptionEntity SpecificationAttributeOption { get; set; }

        /// <summary>
        /// Gets or sets the custom value
        /// </summary>
        public string CustomValue { get; set; }

        /// <summary>
        /// Gets or sets whether the attribute can be filtered by
        /// </summary>
        public bool AllowFiltering { get; set; }

        /// <summary>
        /// Gets or sets whether the attribute will be shown on the product page
        /// </summary>
        public bool ShowOnProductPage { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
