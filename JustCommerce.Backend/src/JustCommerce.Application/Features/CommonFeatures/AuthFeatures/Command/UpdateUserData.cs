using FluentValidation;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Enums;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command
{
    public static class UpdateUserData
    {

        public sealed record Command(Guid UserId,string FirstName, string LastName, string PhoneNumber, bool RemoveCurrentPhoto, Base64File PhotoFile, Language Language, Theme Theme) : IRequest<UserDTO>;

        public sealed class Handler : IRequestHandler<Command, UserDTO>
        {
            private readonly IUserManager _UserManager;
            private readonly IFtpFileManager _FtpFileManager;

            public Handler(IUserManager userManager, IFtpFileManager ftpFileManager)
            {
                _UserManager = userManager;
                _FtpFileManager = ftpFileManager;
            }

            public async Task<UserDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _UserManager.GetByIdAsync(request.UserId, cancellationToken);
                if (user is null)
                {
                    throw new EntityNotFoundException("User", request.UserId);
                }
                string ftpPhoto = user.FtpPhotoFilePath;
                if (request.RemoveCurrentPhoto && !String.IsNullOrEmpty(ftpPhoto))
                {
                    await _FtpFileManager.RemoveFileFromFtpAsync(ftpPhoto, cancellationToken);
                    ftpPhoto = String.Empty;
                }
                if (request.PhotoFile != null)
                {
                    if (!String.IsNullOrEmpty(ftpPhoto))
                    {
                        await _FtpFileManager.RemoveFileFromFtpAsync(ftpPhoto, cancellationToken);
                    }
                    ftpPhoto = await _FtpFileManager.SaveUserPicturePhotoOnFtpAsync(request.PhotoFile, cancellationToken);
                }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                user.Theme = request.Theme;
                user.Language = request.Language;

                await _UserManager.UpdateUserAsync(user, cancellationToken);

                return UserDTO.CreateFromUserEntity(user);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }


    }
}
