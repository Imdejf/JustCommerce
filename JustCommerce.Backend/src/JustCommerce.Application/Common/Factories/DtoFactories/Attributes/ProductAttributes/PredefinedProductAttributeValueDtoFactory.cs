using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes
{
    public static class PredefinedProductAttributeValueDtoFactory
    {
        public static PredefinedProductAttributeValueDTO CreateFromPredefinedProductAttributeValueEntity(PredefinedProductAttributeValueEntity value)
        {
            return new PredefinedProductAttributeValueDTO
            {
                Id = value.Id,
                ProductAttributeId = value.ProductAttributeId,
                Name = value.Name,
                IsPreSelected = value.IsPreSelected,
                Cost = value.Cost,
                DisplayOrder = value.DisplayOrder,
                PriceAdjustment = value.PriceAdjustment,
                WeightAdjustment = value.WeightAdjustment,
                PriceAdjustmentUsePercentage = value.PriceAdjustmentUsePercentage,
                PredefinedProductAttributeValueLang = value.PredefinedProductAttributeValueLang.Select(c => new PredefinedProductAttributeValueLangDTO
                {
                    PredefinedProductAttributeValueId = c.PredefinedProductAttributeValueId,
                    LanguageId = c.LanguageId,
                    Name = c.Name
                }).ToList()
            };
        }
    }
}
