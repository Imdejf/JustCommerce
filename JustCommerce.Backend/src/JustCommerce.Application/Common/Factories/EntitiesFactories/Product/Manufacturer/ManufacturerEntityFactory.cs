using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Application.Features.AdministrationFeatures.Product.Manufacturers.Command;
using JustCommerce.Domain.Entities.Products.Manufacturer;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Manufacturer
{
    public static class ManufacturerEntityFactory
    {

        public static ManufacturerEntity CreateFromCommand(CreateManufacturer.Command command)
        {
            return new ManufacturerEntity
            {
                Name = command.Name,
                SubjectToAcl = command.SubjectToAcl,
                CreatedOnUtc = command.CreatedOnUtc,
                UpdatedOnUtc = command.UpdatedOnUtc,
                DisplayOrder = command.DisplayOrder,
                ManuallyPriceRange = command.ManuallyPriceRange,
                Deleted = command.Deleted,
                PriceTo = command.PriceTo,
                PriceFrom = command.PriceFrom,
                StoreId = command.StoreId,
                Published = command.Published,
                PriceRangeFiltering = command.PriceRangeFiltering,
                ManufacturerLang = command.ManufacturerLang.Select(c => ManufacturerLangEntityFactory.CreateFromDto(c)).ToList()
            };
        }

        public static ManufacturerEntity CreateFromDto(ManufacturerDTO dto)
        {
            return new ManufacturerEntity
            {
                Name = dto.Name,
                SubjectToAcl = dto.SubjectToAcl,
                CreatedOnUtc = dto.CreatedOnUtc,
                UpdatedOnUtc = dto.UpdatedOnUtc,
                DisplayOrder = dto.DisplayOrder,
                ManuallyPriceRange = dto.ManuallyPriceRange,
                Deleted = dto.Deleted,
                PriceTo = dto.PriceTo,
                PriceFrom = dto.PriceFrom,
                StoreId = dto.StoreId,
                Published = dto.Published,
                PriceRangeFiltering = dto.PriceRangeFiltering,
                ManufacturerLang = dto.ManufacturerLang.Select(c => ManufacturerLangEntityFactory.CreateFromDto(c)).ToList()
            };
        }
    }
}
