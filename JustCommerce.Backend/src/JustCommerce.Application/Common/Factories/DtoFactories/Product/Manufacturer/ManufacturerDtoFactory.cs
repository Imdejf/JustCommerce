using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Domain.Entities.Products.Manufacturer;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Manufacturer
{
    public static class ManufacturerDtoFactory
    {
        public static ManufacturerDTO CreateFromEntity(ManufacturerEntity entity)
        {
            return new ManufacturerDTO
            {
                Name = entity.Name,
                StoreId = entity.StoreId,
                SubjectToAcl = entity.SubjectToAcl,
                CreatedOnUtc = entity.CreatedOnUtc,
                Deleted = entity.Deleted,
                DisplayOrder = entity.DisplayOrder,
                ManuallyPriceRange = entity.ManuallyPriceRange,
                PriceFrom = entity.PriceFrom,
                PriceRangeFiltering = entity.PriceRangeFiltering,
                PriceTo = entity.PriceTo,
                Published = entity.Published,
                UpdatedOnUtc = entity.UpdatedOnUtc,
                ManufacturerLang = entity.ManufacturerLang.Select(c => ManufacturerLangDtoFactory.CreateFromEntity(c)).ToList()
            };
        }
    }
}
