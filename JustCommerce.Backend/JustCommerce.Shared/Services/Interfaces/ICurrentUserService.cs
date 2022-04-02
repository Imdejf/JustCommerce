using JustCommerce.Shared.Models;

namespace JustCommerce.Shared.Services.Interfaces
{
    public interface ICurrentUserService
    {
        ApplicationUserJwtClaims CurrentUser { get; }
        void SetCurrentUser(ApplicationUserJwtClaims claims);
        void SetCurrentUser(string jwt);
    }
}
