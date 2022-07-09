﻿using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    /// <summary>
    /// Represents a product attribute
    /// </summary>
    public sealed class ProductAttributeLangEntity
    {
        public Guid ProductAttributeId { get; set; }
        public ProductAttributeEntity ProductAttribute { get; set; } = new ProductAttributeEntity();
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; } = new LanguageEntity();
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;
    }
}
