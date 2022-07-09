using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;

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
    }
}
