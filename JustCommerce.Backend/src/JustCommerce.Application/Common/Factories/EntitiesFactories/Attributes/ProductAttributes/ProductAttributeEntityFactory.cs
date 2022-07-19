using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;

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
                ProductAttributeLang = command.ProductAttributeLangs.Select(c => ProductAttributeLangEntityFactory.CreateFromCommand(c)).ToList(),
                PredefinedProductAttributeValue = command.PredefinedProductAttributeValues.Select(c => PredefinedProductAttributeValueEntityFactory.CreateFromCommand(c)).ToList(),
            };
        }
    }
}
