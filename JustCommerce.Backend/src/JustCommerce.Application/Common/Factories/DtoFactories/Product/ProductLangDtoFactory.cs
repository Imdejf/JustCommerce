using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product
{
    public static class ProductLangDtoFactory
    {
        public static ProductLangDTO CreateFromEntity(ProductLangEntity product)
        {
            return new ProductLangDTO
            {
                Name = product.Name,
                Description = product.Description,
                Synonyms = product.Synonyms,
                ImageDescription = product.ImageDescription,
                Keywords = product.Keywords,
                MetaDescription = product.MetaDescription,
                MetaTitle = product.MetaTitle,
                Tags = product.Tags,
                IsoCode = product.IsoCode,
            };
        }
    }
}
