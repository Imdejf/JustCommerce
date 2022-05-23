using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Query
{
    public static class GetSmsAccount
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<SmsAccountDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<SmsAccountDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<SmsAccountDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var emailAccountList = await _unitOfWorkManagmenet.SmsAccount.GetAllByShopIdAsync(request.ShopId, cancellationToken);

                return emailAccountList.Select(c => SmsAccountDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }

    }
}
