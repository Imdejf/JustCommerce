using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Order.Command
{
    public static class SetOrderStatus
    {

        public sealed record Query(Guid OrderId, OrderStatus OrderStatus) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Query, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderExist = await _unitOfWorkAdministration.Order.ExistsAsync(request.OrderId, cancellationToken);

                if (!orderExist)
                {
                    throw new EntityNotFoundException($"Order with Id : {request.OrderId} doesn`t exists");
                }

                _unitOfWorkAdministration.Order.SetOrderStatus(request.OrderId, request.OrderStatus);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.OrderId).NotEqual(Guid.Empty);
                RuleFor(c => c.OrderStatus).IsInEnum();
            }
        }

    }
}
