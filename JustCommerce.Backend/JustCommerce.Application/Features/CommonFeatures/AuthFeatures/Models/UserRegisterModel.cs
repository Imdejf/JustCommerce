using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models
{
    public sealed class UserRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRegisterSource Source { get; set; }

        public static UserRegisterModel CreateForExternalRegister(string email, string firstName, string lastName, UserRegisterSource registerSource)
        {
            return new(email, true, Guid.NewGuid() + "A123!",firstName,lastName, registerSource);
        }
        public static UserRegisterModel CreateForClassicRegister(string email, string password, string firstName, string lastName)
        {
            return new(email, false, password,firstName,lastName,UserRegisterSource.Standard);
        }

        private UserRegisterModel(string email, bool emailConfirmed, string password, string firstName, string lastName, UserRegisterSource registerSource)
        {
            Email = email;
            EmailConfirmed = emailConfirmed;
            Password = password;
            Source = registerSource;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
