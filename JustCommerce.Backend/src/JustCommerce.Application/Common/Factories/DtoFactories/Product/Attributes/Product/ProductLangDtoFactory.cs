using JustCommerce.Application.Common.DTOs.Product.Product;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.Product
{
    public static class ProductLangDtoFactory
    {
        public static ProductLangDTO CreateFromEntity(ProductLangEntity entity)
        {
            return new ProductLangDTO
            {
                FullDescription = entity.FullDescription,
                MetaDescription = entity.MetaDescription,
                ShortDescription = entity.ShortDescription,
                LanguageId = entity.LanguageId,
                MetaKeywords = entity.MetaKeywords,
                MetaTitle = entity.MetaTitle,
                ProductName = entity.ProductName,
            };
        }
    }
}
