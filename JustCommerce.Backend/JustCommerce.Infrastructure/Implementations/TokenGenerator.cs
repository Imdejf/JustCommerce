using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<UserEntity> _IdentityUserManager;
        public TokenGenerator(UserManager<UserEntity> identityUserManager)
        {
            _IdentityUserManager = identityUserManager;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public Task<string> GeneratePasswordResetTokenAsync(UserEntity user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
