using FluentValidation;
using Hangfire;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Order.Command
{
    public static class SetOrderStatus
    {

        public sealed record Command(Guid OrderId, OrderStatus OrderStatus) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            private readonly IMailSender _mailSender;
            private readonly ISmsApiManager _smsApiManager;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IMailSender mailSender, ISmsApiManager smsApiManager, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _mailSender = mailSender;
                _smsApiManager = smsApiManager;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var test = await _unitOfWorkAdministration.Order.GetByIdAsync(request.OrderId, cancellationToken);
                var order = await _unitOfWorkAdministration.Order.GetFullyObject(request.OrderId, cancellationToken);

                if (order is null)
                {
                    throw new EntityNotFoundException($"Order with Id : {request.OrderId} doesn`t exists");
                }

                order.Status = request.OrderStatus;

                BackgroundJob.Enqueue(() => _mailSender.SendEmailSetOrderStatusAsync(order.CustomerEmail, order.OrderNumber, order.ShopId, EmailType.SetOrderStatus, cancellationToken));

                if (order.SmsNotification)
                {
                    BackgroundJob.Enqueue(() => _smsApiManager.SendSmsForSetStatus(order.CustomerPhone, order.ShopId, order.LanguageVersionId, status(request.OrderStatus), order.OrderNumber, cancellationToken));
                }

                return Unit.Value;
            }
        }

        private static SmsType status(OrderStatus orderStatus)
        {
            switch (orderStatus.ToString())
            {
                case "Placed":
                    return SmsType.OrderPlaced;
                case "InProgress":
                    return SmsType.OrderInProgress;
                case "Send":
                    return SmsType.OrderSend;
                case "Cancel":
                    return SmsType.OrderCancelled;
                default:
                    throw new ArgumentException();
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.OrderId).NotEqual(Guid.Empty);
                //RuleFor(c => c.OrderStatus).IsInEnum();
            }
        }

    }
}
