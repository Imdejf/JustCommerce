using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Common.Interfaces.CommonFeatures
{
    public interface ITokenGenerator
    {
        Task<string> GenerateEmailConfirmationTokenAsync(User user, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(User user, CancellationToken cancellationToken);
    }
}
