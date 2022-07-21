using JustCommerce.Application.Common.DTOs.Customer.Vendor;
using JustCommerce.Application.Features.AdministrationFeatures.Customer.Vendor.Command;
using JustCommerce.Domain.Entities.Vendor;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Customer.Vendor
{
    public sealed class VendorEntityFactory
    {
        public static VendorEntity CreateFromCommand(CreateVendor.Command command)
        {
            return new VendorEntity
            {
                Active = command.Active,
                Deleted = command.Deleted,
                Description = command.Description,
                DisplayOrder = command.DisplayOrder,
                AddressId = command.AddressId,
                AdminComment = command.AdminComment,
                ManuallyPriceRange = command.ManuallyPriceRange,
                Email = command.Email,
                Name = command.Name,
                PriceFrom = command.PriceFrom,
                PriceRangeFiltering = command.ManuallyPriceRange,
                PriceTo = command.PriceTo,
                VendorLang = command.VendorLang.Select(c => new VendorLangEntity
                {
                    MetaDescription = c.MetaDescription,
                    LanguageId = c.LanguageId,
                    MetaKeywords = c.MetaKeywords,
                    MetaTitle = c.MetaTitle
                }).ToList()
            };
        }

        public static VendorEntity CreateFromDto(VendorDTO dto)
        {
            return new VendorEntity
            {
                Active = dto.Active,
                Deleted = dto.Deleted,
                Description = dto.Description,
                DisplayOrder = dto.DisplayOrder,
                AddressId = dto.AddressId,
                AdminComment = dto.AdminComment,
                ManuallyPriceRange = dto.ManuallyPriceRange,
                Email = dto.Email,
                Name = dto.Name,
                PriceFrom = dto.PriceFrom,
                PriceRangeFiltering = dto.ManuallyPriceRange,
                PriceTo = dto.PriceTo,
                VendorLang = dto.VendorLang.Select(c => new VendorLangEntity
                {
                    MetaDescription = c.MetaDescription,
                    LanguageId = c.LanguageId,
                    MetaKeywords = c.MetaKeywords,
                    MetaTitle = c.MetaTitle
                }).ToList()
            };
        }
    }
}
