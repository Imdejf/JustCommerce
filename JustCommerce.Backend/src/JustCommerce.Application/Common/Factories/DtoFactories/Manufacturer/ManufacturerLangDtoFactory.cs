using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Domain.Entities.Products.Manufacturer;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Manufacturer
{
    public static class ManufacturerLangDtoFactory
    {
        public static ManufacturerLangDTO CreateFromEntity(ManufacturerLangEntity dto)
        {
            return new ManufacturerLangDTO
            {
                LanguageId = dto.LanguageId,
                Description = dto.Description,
                ManufacturerId = dto.ManufacturerId,
                MetaDescription = dto.MetaDescription,
                MetaKeywords = dto.MetaKeywords,
                MetaTitle = dto.MetaTitle
            };
        }
    }
}
