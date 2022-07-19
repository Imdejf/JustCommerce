﻿using JustCommerce.Application.Common.DTOs.Attributes.CheckoutAttribute;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.CheckoutAttributes
{
    public static class CheckoutAttributeValueEntityFactory
    {
        public static CheckoutAttributeValueEntity CreateFromDto(CheckoutAttributeValueDTO dto)
        {
            return new CheckoutAttributeValueEntity
            {
                Name = dto.Name,
                ColorSquaresRgb = dto.ColorSquaresRgb,
                DisplayOrder = dto.DisplayOrder,
                IsPreSelected = dto.IsPreSelected,
                PriceAdjustment = dto.PriceAdjustment,
                WeightAdjustment = dto.PriceAdjustment,
                CheckoutAttributeValueLang = dto.CheckoutAttributeValueLang.Select(c => new CheckoutAttributeValueLangEntity
                {
                    Name = c.Name
                }).ToList()
            };
        }
    }
}
