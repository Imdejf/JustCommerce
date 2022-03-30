using E_Commerce.Shared.Models;
using E_Commerce.Shared.Services.Interfaces.JwtService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Services.Implementations.JwtService
{
    internal sealed class JwtDecoder : IJwtDecoder
    {
        public ApplicationUserJwtClaims Decode(string jwt)
        {
            if (String.IsNullOrEmpty(jwt))
            {
                throw new ArgumentException("Token cant be NULL or empty string");
            }
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(jwt);

            return new ApplicationUserJwtClaims
            {
                Id = new Guid(decodedToken.Claims.FirstOrDefault(c => c.Type == nameof(ApplicationUserJwtClaims.Id)).Value),
                Email = decodedToken.Claims.FirstOrDefault(c => c.Type == nameof(ApplicationUserJwtClaims.Email)).Value
            };
        }
    }
}
