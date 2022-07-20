using JustCommerce.Domain.Enums.Attribute;

namespace JustCommerce.Application.Common.DTOs.Product.Attributes.CheckoutAttribute
{
    public sealed class CheckoutAttributeDTO
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string TextPrompt { get; set; } = String.Empty;
        public bool IsRequired { get; set; }
        public bool ShippableProductRequired { get; set; }
        public bool IsTaxExempt { get; set; }
        public Guid? TaxCategoryId { get; set; }
        public AttributeControlType AttributeControlType { get; set; }
        public int DisplayOrder { get; set; }

        //validation fields
        public int? ValidationMinLength { get; set; }
        public int? ValidationMaxLength { get; set; }
        public string ValidationFileAllowedExtensions { get; set; } = String.Empty;
        public int? ValidationFileMaximumSize { get; set; }
        public string DefaultValue { get; set; } = String.Empty;
        public List<CheckoutAttributeValueDTO>? CheckoutAttributeValue { get; set; }
    }
}
