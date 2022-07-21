using JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.ProductAttributes
{
    public static class ProductAttributeDtoFactory
    {
        public static ProductAttributeDTO CreateFromProductAttributeEntity(ProductAttributeEntity productAttribute)
        {
            return new ProductAttributeDTO
            {
                StoreId = productAttribute.StoreId,
                Name = productAttribute.Name,
                Description = productAttribute.Description,
                ProductAttributeLang = productAttribute.ProductAttributeLang.Select(c => new ProductAttributeLangDTO
                {
                    ProductAttributeId = c.ProductAttributeId,
                    LanguageId = c.LanguageId,
                    Name = c.Name,
                }).ToList(),
                PredefinedProductAttributeValue = productAttribute.PredefinedProductAttributeValue.Select(c => PredefinedProductAttributeValueDtoFactory.CreateFromPredefinedProductAttributeValueEntity(c)).ToList(),
                CreatedBy = productAttribute.CreatedBy,
                CreatedDate = productAttribute.CreatedDate,
                LastModifiedBy = productAttribute.LastModifiedBy,
                LastModifiedDate = productAttribute.LastModifiedDate,
            };
        }
    }
}
