using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<CMSUserEntity> _IdentityUserManager;
        public TokenGenerator(UserManager<CMSUserEntity> identityUserManager)
        {
            _IdentityUserManager = identityUserManager;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(CMSUserEntity user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public Task<string> GeneratePasswordResetTokenAsync(CMSUserEntity user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
