using JustCommerce.Domain.Entities;

namespace JustCommerce.Application.Common.Interfaces.CommonFeatures
{
    public interface ITokenGenerator
    {
        Task<string> GenerateEmailConfirmationTokenAsync(User user, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(User user, CancellationToken cancellationToken);
    }
}
