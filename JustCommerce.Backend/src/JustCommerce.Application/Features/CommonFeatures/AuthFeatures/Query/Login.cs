using E_Commerce.Application.Common.Exceptions;
using FluentValidation;
using JustCommerce.Application.Common.Extension;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.CommonFeatures;
using JustCommerce.Application.Models;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Query
{
    public static class Login
    {
        public sealed record Query(string Email, string Password) : IRequestWrapper<JwtGenerationResult>;
        public sealed class Handler : IRequestHandlerWrapper<Query, JwtGenerationResult>
        {
            private readonly IUserManager _UserManager;
            private readonly IJwtGenerator _JwtGenerator;
            public Handler(IUserManager userManager, IJwtGenerator jwtGenerator)
            {
                _UserManager = userManager;
                _JwtGenerator = jwtGenerator;
            }

            public async Task<JwtGenerationResult> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentUser = await _UserManager.GetByEmailAsync(request.Email, cancellationToken);
                if (currentUser is null)
                {
                    throw new EntityNotFoundException($"User with Email {request.Email} is not registered");
                }

                if (currentUser.RegisterSource != Domain.Enums.UserRegisterSource.Standard)
                {
                    throw new IdentityException("Invalid login source.");
                }

                var loginResult = await _UserManager.LoginAsync(currentUser, request.Password, cancellationToken);
                if (!loginResult.IsSuccessful)
                {
                    if (loginResult.Errors.Length > 0)
                        throw new IdentityException(loginResult);
                    else
                        throw new IdentityException("Passed credentails are invalid");
                }

                return _JwtGenerator.Generate(currentUser);
            }
        }
        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.Email).NotEmpty().EmailAddress();
                RuleFor(c => c.Password).Matches(RegexExtension.PasswordValidationRegex);
            }
        }
    }
}
