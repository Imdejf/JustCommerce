using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes
{
    public static class SpecificationAttributeOptionDtoFactory
    {
        public static SpecificationAttributeOptionDTO CreateSpecificationAttributeOptionFromEntity(SpecificationAttributeOptionEntity entity)
        {
            return new SpecificationAttributeOptionDTO
            {
                DisplayOrder = entity.DisplayOrder,
                ColorSquaresRgb = entity.ColorSquaresRgb,
                Name = entity.Name,
                SpecificationAttributeOptionLang = entity.SpecificationAttributeOptionLang.Select(c => new SpecificationAttributeOptionLangDTO
                {
                    LanguageId = c.LanguageId,
                    Name = c.Name
                }).ToList(),
            };
        }

    }
}
