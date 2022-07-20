using JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
{
    public sealed class PredefinedProductAttributeValueLangEntityFactory
    {
        public static PredefinedProductAttributeValueLangEntity CreateFromEntity(PredefinedProductAttributeValueLangDTO value)
        {
            return new PredefinedProductAttributeValueLangEntity
            {
                PredefinedProductAttributeValueId = value.PredefinedProductAttributeValueId,
                LanguageId = value.LanguageId,
                Name = value.Name
            };
        }

        public static PredefinedProductAttributeValueLangEntity CreateFromCommand(CreateProductAttribute.Command.PredefinedProductAttributeValue.PredefinedProductAttributeValueLang value)
        {
            return new PredefinedProductAttributeValueLangEntity
            {
                LanguageId = value.LanguageId,
                Name = value.Name
            };
        }
    }
}
