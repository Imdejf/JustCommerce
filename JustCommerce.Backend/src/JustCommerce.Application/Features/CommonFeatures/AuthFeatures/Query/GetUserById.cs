using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Query
{
    public static class GetUserById
    {
        public sealed record Query(Guid UserId) : IRequestWrapper<UserDTO>;
        public sealed class Handler : IRequestHandlerWrapper<Query, UserDTO>
        {
            private readonly IUserManager _UserManager;
            public Handler(IUserManager userManager)
            {
                _UserManager = userManager;
            }

            public async Task<UserDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var userExists = await _UserManager.ExistsAsync(request.UserId, cancellationToken);
                if (!userExists)
                {
                    throw new EntityNotFoundException("User", request.UserId);
                }

                var user =  await _UserManager.GetByIdAsync(request.UserId, cancellationToken);
                return UserDTO.CreateFromUserEntity(user);
            }
        }
    }
}
