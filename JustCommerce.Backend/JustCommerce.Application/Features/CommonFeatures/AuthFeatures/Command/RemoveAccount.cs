﻿using FluentValidation;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Command
{
    public static class RemoveAccount
    {
        public sealed record Command(Guid UserId) : IRequestWrapper<Unit>;
        public sealed class Handler : IRequestHandler<Command>
        {
            private readonly IUserManager _UserManager;
            public Handler(IUserManager userManager)
            {
                _UserManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentUser = await _UserManager.GetByIdAsync(request.UserId, cancellationToken);
                if (currentUser is null)
                {
                    throw new EntityNotFoundException($"User with Id : {request.UserId} doesn`t exists");
                }

                await _UserManager.RemoveAccountAsync(currentUser, cancellationToken);

                return Unit.Value;
            }
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            }
        }
    }
}