using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product
{
    public static class ProductLangEntityFactory
    {
        public static ProductLangEntity CreateFromDto(ProductLangDTO prodcutLangsDTO)
        {
            return new ProductLangEntity
            {
                Description = prodcutLangsDTO.Description,
                ImageDescription = prodcutLangsDTO.ImageDescription,
                Keywords = prodcutLangsDTO.Keywords,
                MetaDescription = prodcutLangsDTO.MetaDescription,
                MetaTitle = prodcutLangsDTO.MetaTitle,
                Synonyms = prodcutLangsDTO.Synonyms,
                Tags = prodcutLangsDTO.Tags,
                Name = prodcutLangsDTO.Name,
            };
        }

        public static ProductLangEntity CreateFromData(Guid productId, string description, string imageDescription, string keywords, string metaDescription, string metaTitle, string synonyms,
                                                       string tags, string name, string isoCode)
        {
            return new ProductLangEntity
            {
                ProductId = productId,
                Description = description,
                ImageDescription = imageDescription,
                Keywords = keywords,
                MetaDescription = metaDescription,
                MetaTitle = metaTitle,
                Synonyms = synonyms,
                Tags = tags,
                Name = name,
                IsoCode = isoCode
            };
        }
    }
}
