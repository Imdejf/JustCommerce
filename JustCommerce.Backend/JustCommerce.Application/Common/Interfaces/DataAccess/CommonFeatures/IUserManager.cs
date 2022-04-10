using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures
{
    public interface IUserManager
    {
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
        Task<IdentityActionResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword, CancellationToken cancellationToken);
        Task<IdentityActionResult> LoginAsync(UserEntity user, string password, CancellationToken cancellationToken);
        Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken);
        Task<(UserEntity, IdentityActionResult)> RegisterAsync(UserRegisterModel userRegisterModel, CancellationToken cancellationToken);
        Task<IdentityActionResult> ResetPasswordAsync(UserEntity user, string password, string passwordResetToken, CancellationToken cancellationToken);
        Task<IdentityActionResult> ConfirmEmailAsync(UserEntity user, string emailConfirmationToken, CancellationToken cancellationToken);
        Task RemoveAccountAsync(UserEntity user, CancellationToken cancellationToken);
        Task<UserEntity> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<UserEntity> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsInRoleAsync(Guid userId, string role, CancellationToken cancellationToken = default);
    }
}
