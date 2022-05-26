using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Order.Command
{
    public static class ConfirmOrder
    {

        public sealed record Query(Guid OrderId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Query, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagement;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagement)
            {
                _unitOfWorkManagement = unitOfWorkManagement;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.OrderId).NotEqual(Guid.Empty);
            }
        }

    }
}
