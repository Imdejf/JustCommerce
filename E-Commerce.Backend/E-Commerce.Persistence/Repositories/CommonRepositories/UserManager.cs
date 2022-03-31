using E_Commerce.Application.Common.Interfaces.CommonFeatures;
using E_Commerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using E_Commerce.Application.Models;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Persistence.Repositories.CommonRepositories
{
    internal sealed class UserManager : IUserManager
    {
        private readonly ECommerceDbContext _eCommerceDb;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserManager(ECommerceDbContext eCommerceDb, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _eCommerceDb = eCommerceDb;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<IdentityActionResult> ChangePasswordAsync(User user, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityActionResult> ConfirmEmailAsync(User user, string emailConfirmationToken, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityActionResult> LoginAsync(User user, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<(User, IdentityActionResult)> RegisterAsync(UserRegisterModel userRegisterModel, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Email = userRegisterModel.Email,
                UserName = userRegisterModel.Email,
                EmailConfirmed = userRegisterModel.EmailConfirmed,
                RegisterSource = userRegisterModel.Source
            };
            var result = await _userManager.CreateAsync(newUser, userRegisterModel.Password);
            return (newUser, mapIdentityResult(result));
        }

        public Task RemoveAccountAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityActionResult> ResetPasswordAsync(User user, string password, string passwordResetToken, CancellationToken cancellationToken)
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
