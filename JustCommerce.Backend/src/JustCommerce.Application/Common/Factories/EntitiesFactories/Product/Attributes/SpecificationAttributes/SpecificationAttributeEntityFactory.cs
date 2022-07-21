using JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.SpecificationAttributes.Commnad;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.SpecificationAttributes
{
    public static class SpecificationAttributeEntityFactory
    {
        public static SpecificationAttributeEntity CreateSpecificationAttributeFromCommand(CreateSpecificationAttribute.Command command)
        {
            return new SpecificationAttributeEntity
            {
                Name = command.Name,
                DisplayOrder = command.DisplayOrder,
                SpecificationAttributeGroupId = command.SpecificationAttributeGroupId,
                SpecificationAttributeOption = command.SpecificationAttributeOptions.Select(c => SpecificationAttributeOptionEntityFactory.CreateSpecificationAttributeOptionFromCommand(c)).ToList()
            };
        }

    }
}
