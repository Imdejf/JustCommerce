using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities;
using JustCommerce.Shared.Configurations;
using JustCommerce.Shared.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class JwtGenerator : IJwtGenerator
    {
        private readonly JwtServiceConfig _Config;
        public JwtGenerator(IOptions<JwtServiceConfig> options)
        {
            _Config = options.Value;
        }

        public JwtGenerationResult Generate(User user)
        {
            return internalCreate(new ApplicationUserJwtClaims
            {
                Id = user.Id,
                Email = user.Email,
                RegisterSource = (int)user.RegisterSource
            });
        }

        private JwtGenerationResult internalCreate(ApplicationUserJwtClaims claims)
        {
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_Config.TokenLifetimeInMinutes);
            var signingCredentials = createSigningCredentials(_Config.GetRsaPrivateKey());
            var jwt = createJwtSecurityToken(claims, signingCredentials, now, expires);
            return new JwtGenerationResult
            {
                ExpireTimeInMs = (expires - now).TotalMilliseconds,
                Jwt = new JwtSecurityTokenHandler().WriteToken(jwt)
            };
        }
        private SigningCredentials createSigningCredentials(RSA rsa)
        {
            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };
            return signingCredentials;
        }
        private JwtSecurityToken createJwtSecurityToken(ApplicationUserJwtClaims jwtClaims, SigningCredentials signingCredentials, DateTime from, DateTime to)
        {
            var jwt = new JwtSecurityToken(
                audience: _Config.Audience,
                issuer: _Config.Issuer,
                claims: generateClaimsArray(jwtClaims, from),
                notBefore: from,
                expires: to,
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        private Claim[] generateClaimsArray(ApplicationUserJwtClaims jwtClaims, DateTime from)
        {
            var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(from).ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (PropertyInfo prop in jwtClaims.GetType().GetProperties())
            {
                if (!claims.Any(c => c.Type == prop.Name) && !prop.PropertyType.IsGenericType)
                {
                    claims.Add(new Claim(prop.Name, prop.GetValue(jwtClaims).ToString(), prop.PropertyType.ToString()));
                }
            }

            return claims.ToArray();
        }
    }
}
