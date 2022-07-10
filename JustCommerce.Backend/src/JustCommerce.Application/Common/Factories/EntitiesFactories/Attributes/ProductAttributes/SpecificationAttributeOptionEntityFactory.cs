﻿using JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
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