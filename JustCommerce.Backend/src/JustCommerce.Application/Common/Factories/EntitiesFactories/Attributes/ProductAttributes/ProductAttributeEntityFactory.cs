using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes
{
    public static class ProductAttributeEntityFactory
    {
        public static ProductAttributeEntity CreateFromProductCommand(CreateProductAttribute.Command command)
        {
            return new ProductAttributeEntity
            {
                Name = command.Name,
                Description = command.Description,
                StoreId = command.StoreId,
                ProductAttributeLang = command.ProductAttributeLang.Select(c => ProductAttributeLangEntityFactory.CreateFromEntity(c)).ToList(),
                PredefinedProductAttributeValue = command.PredefinedProductAttributeValues.Select(c => PredefinedProductAttributeValueEntityFactory.CreateFromEntity(c)).ToList(),
            };
        }
    }
}
