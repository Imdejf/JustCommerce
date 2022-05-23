using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Command
{
    public static class UpdateSmsAccount
    {

        public sealed record Command(Guid SmsAccountId, SmsGate SmsGate, string From, string Token, bool Test) : IRequestWrapper<SmsAccountDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, SmsAccountDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsAccountDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var smsAccount = await _unitOfWorkManagmenet.SmsAccount.GetByIdAsync(request.SmsAccountId, cancellationToken);
                
                if(smsAccount is null)
                {
                    throw new EntityNotFoundException($"SmsAccount with Id : {request.SmsAccountId} doesn`t exists");
                }

                smsAccount.SmsGate = request.SmsGate;
                smsAccount.Test = request.Test;
                smsAccount.Token = request.Token;
                smsAccount.From = request.From;

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return SmsAccountDtoFactory.CreateFromEntity(smsAccount);
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
