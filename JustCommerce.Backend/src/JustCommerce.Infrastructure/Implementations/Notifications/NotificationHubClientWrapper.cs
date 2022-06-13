using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.Notification;
using JustCommerce.Application.Models.MessageBus.Abstract;
using JustCommerce.Domain.Entities.Notification;

namespace JustCommerce.Infrastructure.Implementations.Notifications
{
    public sealed class NotificationHubClientWrapper : INotificationHubClientWrapper
    {
        private readonly INotificationHubClient _notificationHubClient;
        private readonly IUnitOfWorkCommon _unitOfWorkCommon;

        public NotificationHubClientWrapper(INotificationHubClient notificationHubClient, IUnitOfWorkCommon unitOfWorkCommon)
        {
            _notificationHubClient = notificationHubClient;
            _unitOfWorkCommon = unitOfWorkCommon;
        }

        public async Task SendNotification<TNotification>(TNotification notificationType, CancellationToken cancellationToken)
            where TNotification : BaseNotificationEvent
        {
            var subscribeUserIds = await _unitOfWorkCommon.UserSubscriber.GetSubscribeUserIdsAsync(notificationType.NotificationType, cancellationToken);
            foreach (var userId in subscribeUserIds)
            {
                await _unitOfWorkCommon.UserNotification.AddAsync(new UserNotificationEntity
                {
                    NotificationType = notificationType.NotificationType,
                    CreationDate = DateTime.Now,
                    Completed = false,
                    UserId = userId,
                    Seen = false
                }, cancellationToken);

                await _notificationHubClient.SendAsync(userId, notificationType.GetDescription(), cancellationToken);
            }
            await _unitOfWorkCommon.SaveChangesAsync(cancellationToken);
        }
    }
}
