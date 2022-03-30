using E_Commerce.Shared.Configurations;
using E_Commerce.Shared.Services.Interfaces.JwtService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce.Shared.Services.Implementations.JwtService
{
    internal sealed class JwtValidator : IJwtValidator
    {
        private readonly JwtServiceConfig _Config;
        public JwtValidator(IOptions<JwtServiceConfig> options)
        {
            _Config = options.Value;
        }

        public bool IsValid(string jwt)
        {
            if (String.IsNullOrEmpty(jwt))
            {
                throw new ArgumentException("Token cant be NULL or empty string");
            }
            try
            {
                new JwtSecurityTokenHandler().ValidateToken(jwt, _Config.AsTokenValidationParameters(), out SecurityToken _);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
