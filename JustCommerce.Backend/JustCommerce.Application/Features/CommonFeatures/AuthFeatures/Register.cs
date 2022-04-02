using E_Commerce.Application.Common.Exceptions;
using FluentValidation;
using JustCommerce.Application.Common.Extension;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Domain.Entities;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures
{
    public static class Register
    {
        public sealed record Command(string Login, string Email, string Password, string PasswordCopy, string FirstName, string Surname,
                                     string? CompanyName, string? Nip, string Province, string Street) : IRequestWrapper<User>;

        public sealed class Handler : IRequestHandlerWrapper<Command, User>
        {
            private readonly IUserManager _UserManager;
            private readonly ITokenGenerator _TokenGenerator;
            private readonly IMailSender _EmailSender;
            public Handler(IUserManager userManager, ITokenGenerator tokenGenerator, IMailSender emailSender)
            {
                _UserManager = userManager;
                _TokenGenerator = tokenGenerator;
                _EmailSender = emailSender;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                var isEmailTaken = await _UserManager.IsEmailTakenAsync(request.Email, cancellationToken);
                if (isEmailTaken)
                {
                    throw new InvalidRequestException($"Email {request.Email} is already taken");
                }

                var result = await _UserManager.RegisterAsync(Models.UserRegisterModel.CreateForClassicRegister(request.Email, request.Password, request.FirstName, request.Surname), cancellationToken);

                if (!result.Item2.IsSuccessful)
                {
                    throw new IdentityException(result.Item2);
                }

                var registeredUser = result.Item1;
                var emailConfirmationToken = await _TokenGenerator.GenerateEmailConfirmationTokenAsync(registeredUser, cancellationToken);
                await _EmailSender.SendEmailConfirmationEmailAsync(registeredUser.Email, emailConfirmationToken, registeredUser.Id, cancellationToken);

                return registeredUser;
            }
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Email).NotEmpty().EmailAddress();
                RuleFor(c => c).Must(c => c.Password == c.PasswordCopy);
                RuleFor(c => c.Password).Matches(RegexExtension.PasswordValidationRegex);
                RuleFor(c => c.PasswordCopy).Matches(RegexExtension.PasswordValidationRegex);
            }
        }
    }
}
