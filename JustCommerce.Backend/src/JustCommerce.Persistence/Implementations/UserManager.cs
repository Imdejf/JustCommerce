using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.Implementations.CommonRepositories
{
    internal sealed class UserManager : IUserManager
    {
        private readonly JustCommerceDbContext _justCommerceDb;
        private readonly UserManager<CMSUserEntity> _userManager;
        private readonly SignInManager<CMSUserEntity> _signInManager;

        public UserManager(JustCommerceDbContext justCommerceDb, UserManager<CMSUserEntity> userManager, SignInManager<CMSUserEntity> signInManager)
        {
            _justCommerceDb = justCommerceDb;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityActionResult> ChangePasswordAsync(CMSUserEntity user, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return mapIdentityResult(result);
        }

        public async Task<IdentityActionResult> ConfirmEmailAsync(CMSUserEntity user, string emailConfirmationToken, CancellationToken cancellationToken)
        {
            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);
            return mapIdentityResult(result);
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.AnyAsync(c => c.Id == id, cancellationToken);
        }

        public Task<CMSUserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.Where(c => EF.Functions.Like(c.Email, $"%{email}%")).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<CMSUserEntity?> GetUserByMailOrNameAsync(string mailOrName, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users
                .AsNoTracking()
                .Where(c => c.UserName == mailOrName || c.Email == mailOrName)
                .Include(c => c.UserPermissions)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<CMSUserEntity?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.Where(c => c.Id == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.AnyAsync(c => EF.Functions.Like(c.Email, $"%{email}%"), cancellationToken);
        }

        public async Task<IdentityActionResult> LoginAsync(CMSUserEntity user, string password, CancellationToken cancellationToken)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return mapIdentityResult(result);
        }

        public async Task<bool> IsInRoleAsync(Guid userId, string role, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }


        public async Task<(CMSUserEntity, IdentityActionResult)> RegisterAsync(CMSUserEntity user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return (user, mapIdentityResult(result));
        }

        public async Task UpdateUserAsync(CMSUserEntity user, CancellationToken cancellationToken)
        {
            _justCommerceDb.Users.Update(user);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAccountAsync(CMSUserEntity user, CancellationToken cancellationToken)
        {
            _justCommerceDb.Attach(user).State = EntityState.Deleted;
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task<IdentityActionResult> ResetPasswordAsync(CMSUserEntity user, string password, string passwordResetToken, CancellationToken cancellationToken)
        {
            var result = await _userManager.ResetPasswordAsync(user, passwordResetToken, password);
            return mapIdentityResult(result);
        }

        private IdentityActionResult mapIdentityResult(IdentityResult identityResult)
        {
            if (identityResult.Succeeded) return IdentityActionResult.Success();
            return IdentityActionResult.Failure(identityResult.Errors.Select(c => $"{c.Code} : {c.Description}").ToArray());
        }
        private IdentityActionResult mapIdentityResult(SignInResult signInResult)
        {
            if (!signInResult.Succeeded)
            {
                List<string> errors = new List<string>();
                if (signInResult.IsNotAllowed)
                {
                    errors.Add("Login is not allowed");
                }
                if (signInResult.IsLockedOut)
                {
                    errors.Add("Account is locked out");
                }
                if (signInResult.RequiresTwoFactor)
                {
                    errors.Add("Account requires to factor");
                }
                return IdentityActionResult.Failure(errors.ToArray());
            }
            return IdentityActionResult.Success();
        }
    }
}
