using JustCommerce.Application.Common.DTOs.Attributes.CheckoutAttribute;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Attributes.Checkout
{
    public static class CheckoutAttributeDtoFactory
    {
        public static CheckoutAttributeDTO CreateFromEntity(CheckoutAttributeEntity entity)
        {
            return new CheckoutAttributeDTO
            {
                StoreId = entity.StoreId,
                ShippableProductRequired = entity.ShippableProductRequired,
                DefaultValue = entity.DefaultValue,
                DisplayOrder = entity.DisplayOrder,
                AttributeControlType = entity.AttributeControlType,
                IsRequired = entity.IsRequired,
                IsTaxExempt = entity.IsTaxExempt,
                TextPrompt = entity.TextPrompt,
                Name = entity.Name,
                TaxCategoryId = entity.TaxCategoryId,
                ValidationFileAllowedExtensions = entity.ValidationFileAllowedExtensions,
                ValidationFileMaximumSize = entity.ValidationFileMaximumSize,
                ValidationMaxLength = entity.ValidationFileMaximumSize,
                ValidationMinLength = entity.ValidationFileMaximumSize,
                CheckoutAttributeValue = entity.CheckoutAttributeValue.Select(c => CheckoutAttributeValueDtoFactory.CreateFromEntity(c)).ToList()
            };
        }
    }
}
