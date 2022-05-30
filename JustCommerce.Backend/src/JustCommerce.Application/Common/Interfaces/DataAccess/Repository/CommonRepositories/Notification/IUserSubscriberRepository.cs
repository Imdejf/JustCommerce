using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Notification;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.CommonRepositories.Notification
{
    public interface IUserSubscriberRepository : IBaseRepository<SubscribedUserEntity>
    {
        void Unsubscribe(Guid userId, NotificationType notificationType);
        Task<bool> DoesUserSubscribeToNotificationAsync(Guid userId, NotificationType notificationType, CancellationToken cancellationToken);
        Task<List<Guid>> GetSubscribeUserIdsAsync(NotificationType notificationType, CancellationToken cancellationToken);
    }
}
