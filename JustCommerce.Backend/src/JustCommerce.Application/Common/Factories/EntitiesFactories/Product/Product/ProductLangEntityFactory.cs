using JustCommerce.Application.Common.DTOs.Product.Product;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Product
{
    public static class ProductLangEntityFactory
    {
        public static ProductLangEntity CreateFromDto(ProductLangDTO dto)
        {
            return new ProductLangEntity
            {
                FullDescription = dto.FullDescription,
                MetaDescription = dto.MetaDescription,
                ShortDescription = dto.ShortDescription,
                LanguageId = dto.LanguageId,
                MetaKeywords = dto.MetaKeywords,
                MetaTitle = dto.MetaTitle,
                ProductName = dto.ProductName,
            };
        }
    }
}
