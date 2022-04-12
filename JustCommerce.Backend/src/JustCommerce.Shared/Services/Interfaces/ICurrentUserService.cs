using JustCommerce.Shared.Models;

namespace JustCommerce.Shared.Services.Interfaces
{
    public interface ICurrentUserService
    {
        JwtClaims CurrentUser { get; }
        void SetCurrentUser(JwtClaims claims);
        void SetCurrentUser(string jwt);
    }
}
