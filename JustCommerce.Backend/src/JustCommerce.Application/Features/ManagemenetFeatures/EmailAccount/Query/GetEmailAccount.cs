using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Application.Common.Factories.DtoFactories.Email;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Query
{
    public static class GetEmailAccount
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<EmailAccountDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<EmailAccountDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<EmailAccountDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var emailAccount = await _unitOfWorkManagmenet.EmailAccount.GetAllByShopId(request.ShopId, cancellationToken);

                return emailAccount.Select(c => EmailAccountDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
