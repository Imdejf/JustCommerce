﻿using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Tax;
using JustCommerce.Domain.Enums.Attribute;

namespace JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes
{
    public sealed class CheckoutAttributeEntity : Entity
    {
        /// <summary>
        /// Gets or sets store id
        /// </summary>
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the text prompt
        /// </summary>
        public string TextPrompt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the entity is required
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether shippable products are required in order to display this attribute
        /// </summary>
        public bool ShippableProductRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the attribute is marked as tax exempt
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// Gets or sets the tax category identifier
        /// </summary>
        public Guid? TaxCategoryId { get; set; }
        public TaxCategoryEntity TaxCategory { get; set; }

        /// <summary>
        /// Gets or sets the attribute control type identifier
        /// </summary>
        public AttributeControlType AttributeControlType { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        //validation fields

        /// <summary>
        /// Gets or sets the validation rule for minimum length (for textbox and multiline textbox)
        /// </summary>
        public int? ValidationMinLength { get; set; }

        /// <summary>
        /// Gets or sets the validation rule for maximum length (for textbox and multiline textbox)
        /// </summary>
        public int? ValidationMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the validation rule for file allowed extensions (for file upload)
        /// </summary>
        public string ValidationFileAllowedExtensions { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the validation rule for file maximum size in kilobytes (for file upload)
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// Gets or sets the default value (for textbox and multiline textbox)
        /// </summary>
        public string DefaultValue { get; set; } = string.Empty;
        public Guid? ConditionAttributeId { get; set; }
        public CheckoutAttributeEntity ConditionAttribute { get; set; }

        public ICollection<CheckoutAttributeValueEntity> CheckoutAttributeValue { get; set; }
    }
}
