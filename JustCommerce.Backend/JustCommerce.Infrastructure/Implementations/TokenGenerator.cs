using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<User> _IdentityUserManager;
        public TokenGenerator(UserManager<User> identityUserManager)
        {
            _IdentityUserManager = identityUserManager;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(User user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public Task<string> GeneratePasswordResetTokenAsync(User user, CancellationToken cancellationToken)
        {
            return _IdentityUserManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
