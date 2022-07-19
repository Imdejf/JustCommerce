using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
{
    public sealed class ProductAttributeLangEntityFactory
    {
        public static ProductAttributeLangEntity CreateFromEntity(ProductAttributeLangDTO productAttribute)
        {
            return new ProductAttributeLangEntity
            {
                LanguageId = productAttribute.LanguageId,
                ProductAttributeId = productAttribute.ProductAttributeId,
                Name = productAttribute.Name,
            };
        }

        public static ProductAttributeLangEntity CreateFromCommand(CreateProductAttribute.Command.ProductAttributeLang productAttribute)
        {
            return new ProductAttributeLangEntity
            {
                LanguageId = productAttribute.LanguageId,
                Name = productAttribute.Name,
            };
        }
    }
}
