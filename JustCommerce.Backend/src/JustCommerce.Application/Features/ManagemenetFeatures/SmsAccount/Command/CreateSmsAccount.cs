using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Sms;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Command
{
    public static class CreateSmsAccount
    {

        public sealed record Command(Guid ShopId, SmsGate SmsGate, string From, string Token, bool Test) : IRequestWrapper<SmsAccountDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, SmsAccountDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsAccountDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shopExist = _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (shopExist is null)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var createSmsAccount = SmsAccountEntityFactory.CreateFromCommand(request);

                await _unitOfWorkManagmenet.SmsAccount.AddAsync(createSmsAccount);

                return SmsAccountDtoFactory.CreateFromEntity(createSmsAccount);
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
