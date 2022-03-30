using E_Commerce.Shared.Models;

namespace E_Commerce.Shared.Services.Interfaces
{
    public interface ICurrentUserService
    {
        ApplicationUserJwtClaims CurrentUser { get; }
        void SetCurrentUser(ApplicationUserJwtClaims claims);
        void SetCurrentUser(string jwt);
    }
}
