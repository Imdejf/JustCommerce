using JustCommerce.Shared.Models;

namespace JustCommerce.Shared.Services.Interfaces.JwtService
{
    public interface IJwtDecoder
    {
        JwtClaims Decode(string jwt);
    }
}
