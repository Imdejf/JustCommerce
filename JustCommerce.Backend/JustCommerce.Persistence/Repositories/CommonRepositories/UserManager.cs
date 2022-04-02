using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Models;
using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities;
using JustCommerce.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.Repositories.CommonRepositories
{
    internal sealed class UserManager : IUserManager
    {
        private readonly JustCommerceDbContext _justCommerceDb;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserManager(JustCommerceDbContext justCommerceDb, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _justCommerceDb = justCommerceDb;
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
            return _justCommerceDb.Users.AnyAsync(c => EF.Functions.Like(c.Email, $"%{email}%"), cancellationToken);
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
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                RegisterSource = userRegisterModel.Source,
                CreatedDate = DateTime.Now
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
