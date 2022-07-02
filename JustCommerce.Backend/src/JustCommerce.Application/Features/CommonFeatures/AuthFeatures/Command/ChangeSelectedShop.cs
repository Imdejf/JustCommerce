using FluentValidation;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command
{
    public static class ChangeSelectedShop
    {

        public sealed record Command(Guid UserId, Guid ShopId) : IRequest<JwtGenerationResult>;

        public sealed class Handler : IRequestHandler<Command, JwtGenerationResult>
        {
            private readonly IUserManager _UserManager;
            private readonly IJwtGenerator _JwtGenerator;
            public Handler(IUserManager userManager, IJwtGenerator jwtGenerator)
            {
                _UserManager = userManager;
                _JwtGenerator = jwtGenerator;
            }

            public async Task<JwtGenerationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
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
