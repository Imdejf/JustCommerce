using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class UserEntityFacotry
    {
        public static UserEntity CreateFromRegisterCommand(Register.Command command)
        {
            return new UserEntity
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                EmailConfirmed = false,
                RegisterSource = command.RegisterSource,
                ShopId = command.ShopId,
                UserName = command.Login,
                CreatedDate = DateTime.Now,
            };
        }
    }
}
