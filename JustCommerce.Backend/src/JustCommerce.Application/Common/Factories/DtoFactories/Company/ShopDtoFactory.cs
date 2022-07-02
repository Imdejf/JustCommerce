using JustCommerce.Application.Common.DTOs.Company;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Company
{
    public static class ShopDtoFactory
    {
        public static ShopDTO CreateFromEntity(ShopEntity shop)
        {
            return new ShopDTO
            {
                Id = shop.Id,
                State = shop.State,
                City = shop.City,
                Active = shop.IsActive,
                AddressLine = shop.AddressLine,
                Country = shop.Country,
                Email = shop.Email,
                FullName = shop.FullName,
                Name = shop.Name,
                Zip = shop.Zip
            };
        }
    }
}
