using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class ProductTypePropertyEntityFactory
    {
        public static ProductTypePropertyEntity CreateFromProductTypePropertyCommand(Guid productTypeId,ProductTypePropertyDTO product)
        {
            return new ProductTypePropertyEntity
            {
                ProductTypeId = productTypeId,
                OrderValue = product.OrderValue,
                PropertyType = product.PropertyType,
                //ProductTypePropertyLang = product.ProductTypePropertyLangs.Select(c => new ProductTypePropertyLangEntity
                //{
                //    Name = c.Name,
                //    Value = c.Value,
                //})
            };
        }
    }
}
