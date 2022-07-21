using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.ProductAttributes
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
