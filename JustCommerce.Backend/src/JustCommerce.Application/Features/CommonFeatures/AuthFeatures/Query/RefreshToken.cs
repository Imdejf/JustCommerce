using JustCommerce.Application.Common.Exceptions;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Models;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Services.Interfaces;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Query
{
    public static class RefreshToken
    {
        public sealed record Query() : IRequest<JwtGenerationResult>;
        public sealed class Handler : IRequestHandler<Query, JwtGenerationResult>
        {
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IUserManager _userManager;
            private readonly ICurrentUserService _currentUserService;
            public Handler(IJwtGenerator jwtGenerator, IUserManager userManager, ICurrentUserService currentUserService)
            {
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
                _currentUserService = currentUserService;
            }

            public async Task<JwtGenerationResult> Handle(Query request, CancellationToken cancellationToken)
            {
                if (_currentUserService.CurrentUser.UserId == Guid.Empty)
                {
                    throw new IdentityException("User isn`t loged in");
                }
                var currentUser = await _userManager.GetByIdAsync(_currentUserService.CurrentUser.UserId, cancellationToken);
                if (currentUser is null)
                {
                    throw new EntityNotFoundException($"User with Id {_currentUserService.CurrentUser.UserId} doesn`t exists");
                }

                return _jwtGenerator.Generate(UserDtoFactory.CreateFromEntity(currentUser));
            }
        }
    }
}
