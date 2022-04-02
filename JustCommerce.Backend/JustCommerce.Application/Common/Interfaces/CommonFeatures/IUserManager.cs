using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities;

namespace JustCommerce.Application.Common.Interfaces.CommonFeatures
{
    public interface IUserManager
    {
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
        Task SetProfileTypeAsync(Guid userId, CancellationToken cancellationToken);
        Task SetProfileAccessAsync(Guid userId, bool isProfilePrivate, CancellationToken cancellationToken);
        Task<IdentityActionResult> ChangePasswordAsync(User user, string oldPassword, string newPassword, CancellationToken cancellationToken);
        Task<IdentityActionResult> LoginAsync(User user, string password, CancellationToken cancellationToken);
        Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken);
        Task<(User, IdentityActionResult)> RegisterAsync(UserRegisterModel userRegisterModel, CancellationToken cancellationToken);
        Task<IdentityActionResult> ResetPasswordAsync(User user, string password, string passwordResetToken, CancellationToken cancellationToken);
        Task<IdentityActionResult> ConfirmEmailAsync(User user, string emailConfirmationToken, CancellationToken cancellationToken);
        Task RemoveAccountAsync(User user, CancellationToken cancellationToken);
        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
