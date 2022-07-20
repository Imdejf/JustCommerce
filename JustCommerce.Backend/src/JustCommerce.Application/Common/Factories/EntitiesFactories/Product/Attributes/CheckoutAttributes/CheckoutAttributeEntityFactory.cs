using JustCommerce.Application.Features.AdministrationFeatures.Attributes.CheckoutAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.CheckoutAttributes
{
    public static class CheckoutAttributeEntityFactory
    {
        public static CheckoutAttributeEntity CreateFromCommand(CreateCheckoutAttribute.Command command)
        {
            return new CheckoutAttributeEntity
            {
                StoreId = command.StoreId,
                ShippableProductRequired = command.ShippableProductRequired,
                ValidationFileMaximumSize = command.ValidationFileMaximumSize,
                AttributeControlType = command.AttributeControlType,
                ConditionAttributeId = command.ConditionAttributeId,
                DefaultValue = command.DefaultValue,
                DisplayOrder = command.DisplayOrder,
                IsRequired = command.IsRequired,
                IsTaxExempt = command.IsTaxExempt,
                Name = command.Name,
                TaxCategoryId = command.TaxCategoryId,
                ValidationMaxLength = command.ValidationMaxLength,
                ValidationFileAllowedExtensions = command.ValidationFileAllowedExtensions,
                TextPrompt = command.TextPrompt,
                ValidationMinLength = command.ValidationMinLength,
                CheckoutAttributeValue = command.CheckoutAttributeValue.Select(c => CheckoutAttributeValueEntityFactory.CreateFromDto(c)).ToList()
            };
        }

    }
}
