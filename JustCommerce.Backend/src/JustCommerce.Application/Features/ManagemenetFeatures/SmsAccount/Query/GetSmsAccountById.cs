using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Query
{
    public static class GetSmsAccountById
    {

        public sealed record Query(Guid SmsAccountId) : IRequestWrapper<SmsAccountDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, SmsAccountDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsAccountDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var smsAccount = await _unitOfWorkManagmenet.SmsAccount.GetByIdAsync(request.SmsAccountId, cancellationToken);

                return SmsAccountDtoFactory.CreateFromEntity(smsAccount);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.SmsAccountId).NotEqual(Guid.Empty);
            }
        }
    }
}
