using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Domain.Entities.Products.Manufacturer;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Manufacturer
{
    public static class ManufacturerLangEntityFactory
    {
        public static ManufacturerLangEntity CreateFromDto(ManufacturerLangDTO dto)
        {
            return new ManufacturerLangEntity
            {
                LanguageId = dto.LanguageId,
                Description = dto.Description,
                MetaDescription = dto.MetaDescription,
                MetaTitle = dto.MetaTitle,
                MetaKeywords = dto.MetaKeywords
            };
        }
    }
}
