using E_Commerce.Shared.Models;

namespace E_Commerce.Shared.Services.Interfaces.JwtService
{
    public interface IJwtDecoder
    {
        ApplicationUserJwtClaims Decode(string jwt);
    }
}
