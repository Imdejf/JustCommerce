using FluentValidation;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Common.Interfaces.Service;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Services.Interfaces.Permission;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Permission.Query
{
    public static class GetUserOwnedPermission
    {

        public sealed record Query(Guid UserId) : IRequestWrapper<UserPermissionsDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, UserPermissionsDTO>
        {
            private readonly IUserManager _userManager;
            private readonly IPermissionsMapper _permissionsMapper;
            private readonly IUserPermissionManager _userPermissionManager;
            public Handler(IUserManager userManager, IPermissionsMapper permissionsMapper, IUserPermissionManager userPermissionManager)
            {
                _userManager = userManager;
                _permissionsMapper = permissionsMapper;
                _userPermissionManager = userPermissionManager;
            }

            public async Task<UserPermissionsDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var userExist = await _userManager.ExistsAsync(request.UserId, cancellationToken);

                if (!userExist)
                {
                    throw new EntityNotFoundException($"UserEntity with Id : {request.UserId} doesn`t exists");
                }

                var ownedPermissions = await _userPermissionManager.GetOwnedPermissionsAsync(request.UserId, cancellationToken);

                return UserPermissionsDtoFactory.CreateFromData(request.UserId, ownedPermissions, new List<PermissionDTO>());
            }
        }
    }
}
