using FluentValidation;
using Hangfire;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Exceptions;
using JustCommerce.Application.Common.Extension;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Enums;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces.Permission;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command
{
    public static class Register
    {
        public sealed record Command(string Login, string Email, string Password, string PasswordCopy, string FirstName, string LastName, string PhoneNumber,
                                       Language Language, Profile Profile) : IRequestWrapper<UserEntity>;

        public sealed class Handler : IRequestHandlerWrapper<Command, UserEntity>
        {
            private readonly IUserManager _userManager;
            private readonly ITokenGenerator _tokenGenerator;
            private readonly IMailSender _emailSender;
            private readonly IPermissionsMapper _permissionsMapper;
            private readonly IFtpFileManager _FtpFileManager;


            public Handler(IUserManager userManager, ITokenGenerator tokenGenerator, IMailSender emailSender, IPermissionsMapper permissionsMapper, IFtpFileManager ftpFileManager)
            {
                _userManager = userManager;
                _tokenGenerator = tokenGenerator;
                _emailSender = emailSender;
                _permissionsMapper = permissionsMapper;
                _FtpFileManager = ftpFileManager;
            }

            public async Task<UserEntity> Handle(Command request, CancellationToken cancellationToken)
            {
                var isEmailTaken = await _userManager.IsEmailTakenAsync(request.Email, cancellationToken);
                if (isEmailTaken)
                {
                    throw new InvalidRequestException($"Email {request.Email} is already taken");
                }

                string ftpPhoto = String.Empty;
                //if (request.PhotoFile != null)
                //{
                //    ftpPhoto = await _FtpFileManager.SaveUserPicturePhotoOnFtpAsync(request.PhotoFile, cancellationToken);
                //}

                var newUser = UserEntityFacotry.CreateFromRegisterCommand(request);
                newUser.FtpPhotoFilePath = "/";
                newUser.Theme = Theme.Light;

                newUser.UserPermissions = _permissionsMapper.GetPermissionsByProfile(request.Profile)
                                                   .Select(c => UserPermissionEntityFactory.CreateFromData(c.PermissionDomainName, c.PermissionFlagValue, newUser.Id))
                                                   .ToList();

                var result = await _userManager.RegisterAsync(newUser, request.Password);

                var registeredUser = result.Item1;
                var emailConfirmationToken = await _tokenGenerator.GenerateEmailConfirmationTokenAsync(registeredUser, cancellationToken);


                BackgroundJob.Enqueue(() => _emailSender.SendEmailConfirmationEmailAsync(registeredUser.Email, emailConfirmationToken, registeredUser.Id, EmailType.ConfirmAccount, cancellationToken));

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
