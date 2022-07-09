using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Service
{
    public interface IUserManager
    {
        Task UpdateUserAsync(CMSUserEntity user, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
        Task<IdentityActionResult> ChangePasswordAsync(CMSUserEntity user, string oldPassword, string newPassword, CancellationToken cancellationToken);
        Task<IdentityActionResult> LoginAsync(CMSUserEntity user, string password, CancellationToken cancellationToken);
        Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken);
        Task<(CMSUserEntity, IdentityActionResult)> RegisterAsync(CMSUserEntity user, string password);
        Task<IdentityActionResult> ResetPasswordAsync(CMSUserEntity user, string password, string passwordResetToken, CancellationToken cancellationToken);
        Task<IdentityActionResult> ConfirmEmailAsync(CMSUserEntity user, string emailConfirmationToken, CancellationToken cancellationToken);
        Task RemoveAccountAsync(CMSUserEntity user, CancellationToken cancellationToken);
        Task<CMSUserEntity> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<CMSUserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<CMSUserEntity?> GetUserByMailOrNameAsync(string mailOrName, CancellationToken cancellationToken);
        Task<bool> IsInRoleAsync(Guid userId, string role, CancellationToken cancellationToken = default);
    }
}
