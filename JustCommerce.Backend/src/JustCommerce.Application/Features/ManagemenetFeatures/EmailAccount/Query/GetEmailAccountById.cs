using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Application.Common.Factories.DtoFactories.Email;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Query
{
    public static class GetEmailAccountById
    {

        public sealed record Query(Guid EmailAccountId) : IRequestWrapper<EmailAccountDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, EmailAccountDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<EmailAccountDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var emailAccount = await _unitOfWorkManagmenet.EmailAccount.GetByIdAsync(request.EmailAccountId, cancellationToken);

                return EmailAccountDtoFactory.CreateFromEntity(emailAccount);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.EmailAccountId).NotEqual(Guid.Empty);
            }
        }

    }
}
