﻿using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
{
    public static class PredefinedProductAttributeValueEntityFactory
    {
        public static PredefinedProductAttributeValueEntity CreateFromEntity(PredefinedProductAttributeValueDTO value)
        {
            return new PredefinedProductAttributeValueEntity
            {
                Id = value.Id,
                ProductAttributeId = value.ProductAttributeId,
                Name = value.Name,
                Cost = value.Cost,
                IsPreSelected = value.IsPreSelected,
                DisplayOrder = value.DisplayOrder,
                PriceAdjustment = value.PriceAdjustment,
                WeightAdjustment = value.WeightAdjustment,
                PriceAdjustmentUsePercentage = value.PriceAdjustmentUsePercentage,
                PredefinedProductAttributeValueLang = value.PredefinedProductAttributeValueLang.Select(c => PredefinedProductAttributeValueLangEntityFactory.CreateFromEntity(c)).ToList(),
            };
        }

        public static PredefinedProductAttributeValueEntity CreateFromCommand(CreateProductAttribute.Command.PredefinedProductAttributeValue value)
        {
            return new PredefinedProductAttributeValueEntity
            {
                Name = value.Name,
                Cost = value.Cost,
                IsPreSelected = value.IsPreSelected,
                DisplayOrder = value.DisplayOrder,
                PriceAdjustment = value.PriceAdjustment,
                WeightAdjustment = value.WeightAdjustment,
                PriceAdjustmentUsePercentage = value.PriceAdjustmentUsePercentage,
                PredefinedProductAttributeValueLang = value.PredefinedProductAttributeValueLangs.Select(c => PredefinedProductAttributeValueLangEntityFactory.CreateFromCommand(c)).ToList(),
            };
        }
    }
}