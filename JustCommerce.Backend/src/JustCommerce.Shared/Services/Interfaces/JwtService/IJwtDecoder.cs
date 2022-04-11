using JustCommerce.Shared.Models;

namespace JustCommerce.Shared.Services.Interfaces.JwtService
{
    public interface IJwtDecoder
    {
        ApplicationUserJwtClaims Decode(string jwt);
    }
}
