using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.CommonFeatures
{
    public interface ITokenGenerator
    {
        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(UserEntity user, CancellationToken cancellationToken);
    }
}
