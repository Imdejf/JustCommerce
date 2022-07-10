﻿using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Attributes
{
    public sealed class PredefinedProductAttributeValueLangEntity
    {
        public Guid PredefinedProductAttributeValueId { get; set; }
        public PredefinedProductAttributeValueEntity PredefinedProductAttributeValue { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}