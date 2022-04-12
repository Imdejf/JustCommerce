using FluentValidation;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Permission.Query
{
    public static class GetUserPermission
    {

        public sealed record Query(Guid UserId) : IRequestWrapper<UserPermissionsDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, UserPermissionsDTO>
        {
            private readonly IMediator _mediator;
            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<UserPermissionsDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var userPermissions = await _mediator.Send(new GetUserOwnedPermission.Query(request.UserId), cancellationToken);
                var ownedPermissions = userPermissions.Permission
                    .Select(c => c.Item1)
                    .ToList();

                var allPermissions = await _mediator.Send(new GetAllPermission.Query(), cancellationToken);
                var unownedPermissions = allPermissions
                    .Where(c => !ownedPermissions.Contains(c))
                    .ToList();

                return UserPermissionsDtoFactory.CreateFromData(request.UserId, ownedPermissions, unownedPermissions);
            }
        }
    }
}
