using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Command
{
    public static class RemoveSmsAccount
    {

        public sealed record Command(Guid SmsAccountId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkManagmenet.SmsAccount.ExistsAsync(request.SmsAccountId, cancellationToken))
                {
                    throw new EntityNotFoundException($"SmsAccount with Id : {request.SmsAccountId} doesn`t exists");
                }

                _unitOfWorkManagmenet.SmsAccount.RemoveById(request.SmsAccountId);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return Unit.Value;
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
