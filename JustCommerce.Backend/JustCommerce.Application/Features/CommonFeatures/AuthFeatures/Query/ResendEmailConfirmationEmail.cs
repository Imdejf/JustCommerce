﻿using E_Commerce.Application.Common.Exceptions;
using FluentValidation;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Query
{
    public static class ResendEmailConfirmationEmail
    {
        public sealed record Query(string Email) : IRequestWrapper<Unit>;
        public sealed class Handler : IRequestHandler<Query,Unit>
        {
            private readonly IUserManager _UserManager;
            private readonly ITokenGenerator _TokenGenerator;
            private readonly IMailSender _EmailSender;
            public Handler(IUserManager userManager, ITokenGenerator tokenGenerator, IMailSender emailSender)
            {
                _UserManager = userManager;
                _TokenGenerator = tokenGenerator;
                _EmailSender = emailSender;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentUser = await _UserManager.GetByEmailAsync(request.Email, cancellationToken);
                if (currentUser is null)
                {
                    throw new EntityNotFoundException($"User with Email {request.Email} doesn`t exists");
                }
                if (currentUser.EmailConfirmed)
                {
                    throw new IdentityException($"User with Email {request.Email} has already confirmed his email");
                }
                var emailConfiramtionToken = await _TokenGenerator.GenerateEmailConfirmationTokenAsync(currentUser, cancellationToken);
                await _EmailSender.SendEmailConfirmationEmailAsync(currentUser.Email, emailConfiramtionToken, currentUser.Id, cancellationToken);

                return Unit.Value;
            }
        }
        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.Email).NotEmpty().EmailAddress();
            }
        }
    }
}
