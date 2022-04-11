using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using JustCommerce.Shared.Services.Interfaces.JwtService;

namespace JustCommerce.Shared.Services.Implementations
{
    internal sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IJwtValidator _JwtValidator;
        private readonly IJwtDecoder _JwtDecoder;
        private ApplicationUserJwtClaims _DefaultClaims => new ApplicationUserJwtClaims
        {
            Id = Guid.Empty,
            Email = "anonymous@email.com"
        };

        public CurrentUserService(IJwtValidator jwtValidator, IJwtDecoder jwtDecoder)
        {
            _JwtValidator = jwtValidator;
            _JwtDecoder = jwtDecoder;
            currentUser = _DefaultClaims;
        }


        public ApplicationUserJwtClaims CurrentUser => currentUser;
        private ApplicationUserJwtClaims currentUser;

        public void SetCurrentUser(ApplicationUserJwtClaims claims)
        {
            currentUser = claims;
        }

        public void SetCurrentUser(string jwt)
        {
            if (_JwtValidator.IsValid(jwt))
            {
                currentUser = _JwtDecoder.Decode(jwt);
            }
            else
            {
                currentUser = _DefaultClaims;
            }
        }
    }
}
