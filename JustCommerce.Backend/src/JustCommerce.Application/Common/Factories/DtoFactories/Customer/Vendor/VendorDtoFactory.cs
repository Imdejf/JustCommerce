using JustCommerce.Application.Common.DTOs.Customer.Vendor;
using JustCommerce.Domain.Entities.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Customer.Vendor
{
    public static class VendorDtoFactory
    {
        public static VendorDTO CreateFromEntity(VendorEntity vendor)
        {
            return new VendorDTO
            {
                Active = vendor.Active,
                Deleted = vendor.Deleted,
                Description = vendor.Description,
                DisplayOrder = vendor.DisplayOrder,
                AddressId = vendor.AddressId,
                AdminComment = vendor.AdminComment,
                ManuallyPriceRange = vendor.ManuallyPriceRange,
                Email = vendor.Email,
                Name = vendor.Name,
                PriceFrom = vendor.PriceFrom,
                PriceRangeFiltering = vendor.ManuallyPriceRange,
                PriceTo = vendor.PriceTo,
                VendorLang = vendor.VendorLang.Select(c => new VendorLangDTO
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
