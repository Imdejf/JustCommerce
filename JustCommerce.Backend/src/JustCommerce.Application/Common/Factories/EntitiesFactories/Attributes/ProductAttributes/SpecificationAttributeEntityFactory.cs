﻿using JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
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
