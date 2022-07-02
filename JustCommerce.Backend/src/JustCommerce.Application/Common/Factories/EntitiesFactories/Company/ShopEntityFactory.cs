using JustCommerce.Application.Features.ManagemenetFeatures.Shop.Command;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Company
{
    public static class ShopEntityFactory
    {
        public static ShopEntity CreateFromShopCommand(CreateShop.Command command)
        {
            return new ShopEntity
            {
                Id = command.Id,
                State = command.State,
                IsActive = command.IsActive,
                AddressLine = command.AddressLine,
                City = command.City,
                Country = command.Country,
                Email = command.Email,
                FullName = command.FullName,
                Name = command.Name,
                Zip = command.Zip
            };
        }
    }
}
