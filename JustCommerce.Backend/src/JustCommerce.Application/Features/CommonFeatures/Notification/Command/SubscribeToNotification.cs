using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Domain.Entities.Notification;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.Notification.Command
{
    public static class SubscribeToNotification
    {
        public sealed record Command(Guid UserId, NotificationType NotificationType) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkCommon _unitOfWorkCommon;
            private readonly IUserManager _userManager;

            public Handler(IUnitOfWorkCommon unitOfWorkCommon, IUserManager userManager)
            {
                _unitOfWorkCommon = unitOfWorkCommon;
                _userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _userManager.ExistsAsync(request.UserId, cancellationToken))
                {
                    throw new EntityNotFoundException("User not found");
                }

                if (!await _unitOfWorkCommon.Notification.ExistsAsync(request.NotificationType, cancellationToken))
                {
                    throw new EntityNotFoundException("Notification not found");
                }

                if (await _unitOfWorkCommon.UserSubscriber.DoesUserSubscribeToNotificationAsync(request.UserId, request.NotificationType, cancellationToken))
                {
                    throw new InvalidRequestException("User already subscribe to notification");
                }

                var newSubscriber = new UserSubscribedEntity
                {
                    NotificationType = request.NotificationType,
                    UserId = request.UserId
                };

                await _unitOfWorkCommon.UserSubscriber.AddAsync(newSubscriber, cancellationToken);
                await _unitOfWorkCommon.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class SubscribeToNotificationValidator : AbstractValidator<Command>
        {
            public SubscribeToNotificationValidator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
                RuleFor(c => c.NotificationType).IsInEnum();
            }
        }
    }
}
