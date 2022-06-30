using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Factories.DtoFactories
{
    public static class ProductTypePropertyLangDtoFactory
    {
        public static ProductTypePropertyLangDTO CreateFromEntity(ProductTypePropertyLangEntity entity)
        {
            return new ProductTypePropertyLangDTO
            {
                Name = entity.Name,
                DefualtValue = entity.DefualtValue,
                IsoCode = entity.IsoCode,
                Value = entity.Value,
            };
        }
    }
}
