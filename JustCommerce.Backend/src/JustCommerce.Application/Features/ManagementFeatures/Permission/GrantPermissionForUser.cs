using E_Commerce.Shared.Services.Interfaces.Permission;
using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagementFeatures.Permission
{
    public static class GrantPermissionForUser
    {
        public sealed record Command(Guid UserId, string PermissionDomainName, int PermissionFlagValue) : IRequestWrapper<UserPermissionEntity>;

        public sealed class Handler : IRequestHandlerWrapper<Command, UserPermissionEntity>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            private readonly IPermissionValidator _permissionValidator;
            private readonly IUserManager _userManager;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagement, IPermissionValidator permissionValidator, IUserManager userManager)
            {
                _unitOfWorkManagmenet = unitOfWorkManagement;
                _permissionValidator = permissionValidator;
                _userManager = userManager;
            }

            public async Task<UserPermissionEntity> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _userManager.ExistsAsync(request.UserId, cancellationToken))
                {
                    throw new EntityNotFoundException("User not exists");
                }
                //if (!_permissionValidator.IsPermissionValid(request.PermissionDomainName, request.PermissionFlagValue)) 
                //{
                //    throw new InvalidRequestException("Send invalid permission");
                //}
                if (await _unitOfWorkManagmenet.Permission.DoesUserHavePermissionAsync(request.UserId, request.PermissionDomainName, cancellationToken))
                {
                    throw new InvalidRequestException("Send already has permission");
                }
                var newUserPermission = new UserPermissionEntity
                {
                    UserId = request.UserId,
                    PermissionDomainName = request.PermissionDomainName,
                    PermissionFlagValue = request.PermissionFlagValue
                };

                await _unitOfWorkManagmenet.Permission.AddAsync(newUserPermission, cancellationToken);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return newUserPermission;
            }
        }

        public sealed class GrantPermissionForUserValidator : AbstractValidator<Command>
        {
            public GrantPermissionForUserValidator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
                RuleFor(c => c.PermissionDomainName).NotEmpty();
            }
        }
    }
}
