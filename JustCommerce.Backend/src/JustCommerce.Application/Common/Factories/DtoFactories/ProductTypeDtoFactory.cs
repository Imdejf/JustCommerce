using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Factories.DtoFactories
{
    public static class ProductTypeDtoFactory
    {
        public static ProductTypeDTO CreateFromEntity(ProductTypeEntity productType)
        {
            return new ProductTypeDTO
            {
                Id = productType.Id,
                Name = productType.Name,
                ProductTypeProperty = productType.ProductTypeProperty?.Select(c => ProductTypePropertyDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
