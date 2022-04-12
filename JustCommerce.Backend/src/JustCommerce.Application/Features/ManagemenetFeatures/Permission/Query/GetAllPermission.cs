﻿using FluentValidation;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
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
    public static class GetAllPermission
    {

        public sealed record Query() : IRequestWrapper<IEnumerable<PermissionDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, IEnumerable<PermissionDTO>>
        {
            private readonly IPermissionsMapper _permissionsMapper;
            public Handler(IPermissionsMapper permissionsMapper)
            {
                _permissionsMapper = permissionsMapper;
            }

            public async Task<IEnumerable<PermissionDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var allPermissions = _permissionsMapper
                      .GetPermissionsAsObjects()
                      .Select(c => PermissionDtoFactory.CreateFromData(c.PermissionDomainName, c.PermissionFlagName, c.PermissionFlagValue));
                
                return allPermissions;
            }
        }
    }
}
