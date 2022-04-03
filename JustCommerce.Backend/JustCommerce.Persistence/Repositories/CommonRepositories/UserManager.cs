using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.Repositories.CommonRepositories
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

        public Task<IdentityActionResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityActionResult> ConfirmEmailAsync(UserEntity user, string emailConfirmationToken, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken)
        {
            return _justCommerceDb.Users.AnyAsync(c => EF.Functions.Like(c.Email, $"%{email}%"), cancellationToken);
        }

        public Task<IdentityActionResult> LoginAsync(UserEntity user, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
                CreatedDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterModel.Password);

            return (newUser, mapIdentityResult(result));
        }


        public Task RemoveAccountAsync(UserEntity user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityActionResult> ResetPasswordAsync(UserEntity user, string password, string passwordResetToken, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetProfileAccessAsync(Guid userId, bool isProfilePrivate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetProfileTypeAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
