using JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures;
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
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserManager(JustCommerceDbContext justCommerceDb, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _justCommerceDb = justCommerceDb;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityActionResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return mapIdentityResult(result);
        }

        public async Task<IdentityActionResult> ConfirmEmailAsync(UserEntity user, string emailConfirmationToken, CancellationToken cancellationToken)
        {
            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);
            return mapIdentityResult(result);
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.AnyAsync(c => c.Id == id, cancellationToken);
        }

        public Task<UserEntity> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.Where(c => EF.Functions.Like(c.Email, $"%{email}%")).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<UserEntity> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.Where(c => c.Id == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.AnyAsync(c => EF.Functions.Like(c.Email, $"%{email}%"), cancellationToken);
        }

        public async Task<IdentityActionResult> LoginAsync(UserEntity user, string password, CancellationToken cancellationToken)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return mapIdentityResult(result);
        }

        public async Task<bool> IsInRoleAsync(Guid userId, string role, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }


        public async Task<(UserEntity, IdentityActionResult)> RegisterAsync(UserRegisterModel userRegisterModel, CancellationToken cancellationToken)
        {
            var newUser = new UserEntity
            {
                Email = userRegisterModel.Email,
                UserName = userRegisterModel.Email,
                EmailConfirmed = userRegisterModel.EmailConfirmed,
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                RegisterSource = userRegisterModel.Source,
                CreatedDate = DateTime.Now,
                ShopId = userRegisterModel.ShopId
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterModel.Password);

            return (newUser, mapIdentityResult(result));
        }


        public async Task RemoveAccountAsync(UserEntity user, CancellationToken cancellationToken)
        {
            _justCommerceDb.Attach(user).State = EntityState.Deleted;
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task<IdentityActionResult> ResetPasswordAsync(UserEntity user, string password, string passwordResetToken, CancellationToken cancellationToken)
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
