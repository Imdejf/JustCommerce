using JustCommerce.Application.Common.DTOs.Product.Attributes.CheckoutAttribute;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.CheckoutAttributes
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
                    LanguageId = c.LanguageId,
                    Name = c.Name
                }).ToList()
            };
        }
    }
}
