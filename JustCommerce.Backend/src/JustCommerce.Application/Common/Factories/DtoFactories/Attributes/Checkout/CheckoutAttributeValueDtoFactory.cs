using JustCommerce.Application.Common.DTOs.Product.Attributes.CheckoutAttribute;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Attributes.Checkout
{
    public static class CheckoutAttributeValueDtoFactory
    {
        public static CheckoutAttributeValueDTO CreateFromEntity(CheckoutAttributeValueEntity entity)
        {
            return new CheckoutAttributeValueDTO
            {
                Name = entity.Name,
                ColorSquaresRgb = entity.ColorSquaresRgb,
                IsPreSelected = entity.IsPreSelected,
                CheckoutAttributeId = entity.CheckoutAttributeId,
                DisplayOrder = entity.DisplayOrder,
                PriceAdjustment = entity.PriceAdjustment,
                WeightAdjustment = entity.WeightAdjustment,
                CheckoutAttributeValueLang = entity.CheckoutAttributeValueLang.Select(c => new CheckoutAttributeValueLangDTO
                {
                    Name = c.Name,
                    LanguageId = c.LanguageId,
                    CheckoutAttributeValueId = c.CheckoutAttributeValueId
                }).ToList()
            };
        }
    }
}
