using FluentValidation;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.AuthFeatures.Query
{
    public static class SendPasswordResetEmail
    {
        public sealed record Query(string Email, Guid ShopId) : IRequestWrapper<Unit>;
        public sealed class Handler : IRequestHandlerWrapper<Query, Unit>
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

                var emailConfiramtionToken = await _TokenGenerator.GeneratePasswordResetTokenAsync(currentUser, cancellationToken);
                await _EmailSender.SendPasswordResetEmailAsync(currentUser.Email, emailConfiramtionToken, currentUser.Id, request.ShopId,Domain.Enums.EmailType.ResetPassword, cancellationToken);

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
