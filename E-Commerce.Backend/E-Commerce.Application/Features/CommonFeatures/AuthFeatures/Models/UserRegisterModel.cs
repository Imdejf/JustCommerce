using E_Commerce.Domain.Enums;

namespace E_Commerce.Application.Features.CommonFeatures.AuthFeatures.Models
{
    public sealed class UserRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserRegisterSource Source { get; set; }

        public static UserRegisterModel CreateForExternalRegister(string email, UserRegisterSource registerSource)
        {
            return new(email, true, Guid.NewGuid() + "A123!", registerSource);
        }
        public static UserRegisterModel CreateForClassicRegister(string email, string password)
        {
            return new(email, false, password, UserRegisterSource.Standard);
        }

        private UserRegisterModel(string email, bool emailConfirmed, string password, UserRegisterSource registerSource)
        {
            Email = email;
            EmailConfirmed = emailConfirmed;
            Password = password;
            Source = registerSource;
        }
    }
}
