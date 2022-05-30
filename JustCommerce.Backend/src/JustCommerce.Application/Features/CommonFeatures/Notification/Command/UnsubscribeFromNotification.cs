using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.Notification.Command
{
    public static class UnsubscribeFromNotification
    {
        public sealed record Command(Guid UserId, NotificationType NotificationType) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkCommon _unitOfWorkCommon;

            public Handler(IUnitOfWorkCommon unitOfWorkCommon)
            {
                _unitOfWorkCommon = unitOfWorkCommon;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkCommon.Notification.ExistsAsync(request.NotificationType, cancellationToken))
                {
                    throw new EntityNotFoundException("Notification not found");
                }

                if (!await _unitOfWorkCommon.UserSubscriber.DoesUserSubscribeToNotificationAsync(request.UserId, request.NotificationType, cancellationToken))
                {
                    throw new EntityNotFoundException("User not subscribed to notification");
                }

                _unitOfWorkCommon.UserSubscriber.Unsubscribe(request.UserId, request.NotificationType);
                await _unitOfWorkCommon.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class UnsubscribeFromNotificationValidator : AbstractValidator<Command>
        {
            public UnsubscribeFromNotificationValidator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
                RuleFor(c => c.NotificationType).IsInEnum();
            }
        }
    }
}
