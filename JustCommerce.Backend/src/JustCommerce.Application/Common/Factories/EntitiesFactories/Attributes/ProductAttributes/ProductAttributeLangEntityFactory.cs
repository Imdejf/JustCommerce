using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;

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
    }
}
