﻿using JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.SpecificationAttributes.Commnad;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.SpecificationAttributes
{
    public static class SpecificationAttributeOptionEntityFactory
    {
        public static SpecificationAttributeOptionEntity CreateSpecificationAttributeOptionFromCommand(CreateSpecificationAttribute.Command.SpecificationAttributeOption command)
        {
            return new SpecificationAttributeOptionEntity
            {
                DisplayOrder = command.DisplayOrder,
                ColorSquaresRgb = command.ColorSquaresRgb,
                Name = command.Name,
                SpecificationAttributeOptionLang = command.SpecificationAttributeOptionLangs.Select(c => new SpecificationAttributeOptionLangEntity
                {
                    LanguageId = c.LanguageId,
                    Name = c.Name
                }).ToList(),
            };
        }

    }
}
