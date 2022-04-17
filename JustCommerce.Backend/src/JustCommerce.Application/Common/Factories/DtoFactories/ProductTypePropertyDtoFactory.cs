using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Factories.DtoFactories
{
    public static class ProductTypePropertyDtoFactory
    {
        public static ProductTypePropertyDTO CreateFromEntity(ProductTypePropertyEntity entity)
        {
            return new ProductTypePropertyDTO
            {
                OrderValue = entity.OrderValue,
                PropertyType = entity.PropertyType,
                ProductTypePropertyLangs = entity.ProductTypePropertyLang?.Select(c => ProductTypePropertyLangDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
