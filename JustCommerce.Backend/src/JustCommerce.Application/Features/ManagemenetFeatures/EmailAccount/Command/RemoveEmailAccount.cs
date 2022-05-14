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

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Command
{
    public static class RemoveEmailAccount
    {

        public sealed record Command(Guid EmailAccountId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var emailAccount = await _unitOfWorkManagmenet.EmailAccount.ExistsAsync(request.EmailAccountId);

                if (!emailAccount)
                {
                    throw new EntityNotFoundException($"EmailAccount with Id : {request.EmailAccountId} doesn`t exists");
                }

                _unitOfWorkManagmenet.EmailAccount.RemoveById(request.EmailAccountId);
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
