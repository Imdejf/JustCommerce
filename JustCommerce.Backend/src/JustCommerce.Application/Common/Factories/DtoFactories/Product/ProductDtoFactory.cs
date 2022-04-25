using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product
{
    public class ProductDtoFactory
    {
        public static ProductDTO CreateFromEntity(ProductEntity product)
        {
            return new ProductDTO
            { 
                Id = product.Id,
                Slug = product.Slug,
                Top = product.Top,
                Newsletter = product.Newsletter,
                Active = product.Active,
                AvailabilityType = product.AvailabilityType,
                ProductLang = product.ProductLang?.Select(c => ProductLangDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
