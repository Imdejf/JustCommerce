using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class ProductTypePropertyLangEntityFactory
    {
        public static ProductTypePropertyLangEntity CreateFromDto(ProductTypePropertyLangDTO productTypeProperty)
        {
            return new ProductTypePropertyLangEntity
            {
                Name = productTypeProperty.Name,
                Value = productTypeProperty.Value,
                DefualtValue = productTypeProperty.DefualtValue,
                IsoCode = productTypeProperty.IsoCode
            };
        }

        public static ProductTypePropertyLangEntity CreateFromData(Guid productTypePropertyId, string name, string value, string defualtValue, string isoCode)
        {
            return new ProductTypePropertyLangEntity
            {
                ProductTypePropertyId = productTypePropertyId,
                Name = name,
                Value = value,
                DefualtValue = defualtValue,
                IsoCode = isoCode
            };
        }
    }
}
