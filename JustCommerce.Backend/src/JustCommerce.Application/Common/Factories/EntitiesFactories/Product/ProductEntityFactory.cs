using JustCommerce.Application.Features.AdministrationFeatures.Product.Command;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product
{
    public static class ProductEntityFactory
    {
        public static ProductEntity CreateFromProductCommand(CreateProduct.Command command)
        {
            return new ProductEntity
            {
                ProductTypeId = command.ProductTypeId,
                Active = command.Active,
                AvailabilityType = command.AvailabilityType,
                Newsletter = command.Newsletter,
                Slug = command.Slug,
                Top = command.Top,
                ProductCategory = command.Category?.Select(c => new ProductCategoryEntity
                {
                    Category = null,
                    CategoryId = c.CategoryId,
                    Product = null,
                    ProductId = Guid.Empty
                }).ToArray()
            };
        }
    }
}
