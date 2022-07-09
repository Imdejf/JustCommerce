using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Service
{
    public interface ITokenGenerator
    {
        Task<string> GenerateEmailConfirmationTokenAsync(CMSUserEntity user, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(CMSUserEntity user, CancellationToken cancellationToken);
    }
}
