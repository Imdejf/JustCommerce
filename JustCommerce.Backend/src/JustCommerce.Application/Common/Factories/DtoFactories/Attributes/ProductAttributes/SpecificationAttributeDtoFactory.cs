using JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes
{
    public static class SpecificationAttributeDtoFactory
    {
        public static SpecificationAttributeDTO CreateSpecificationAttributeFromEntity(SpecificationAttributeEntity entity)
        {
            return new SpecificationAttributeDTO
            {
                Name = entity.Name,
                DisplayOrder = entity.DisplayOrder,
                SpecificationAttributeGroupId = entity.SpecificationAttributeGroupId,
                SpecificationAttributeOption = entity.SpecificationAttributeOption.Select(c => SpecificationAttributeOptionDtoFactory.CreateSpecificationAttributeOptionFromEntity(c)).ToList()
            };
        }

    }
}
