using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Identity
{
    public static class UserEntityFacotry
    {
        public static CMSUserEntity CreateFromRegisterCommand(Register.Command command)
        {
            return new CMSUserEntity
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                EmailConfirmed = false,
                UserName = command.Login,
                CreatedDate = DateTime.Now,
            };
        }
    }
}
