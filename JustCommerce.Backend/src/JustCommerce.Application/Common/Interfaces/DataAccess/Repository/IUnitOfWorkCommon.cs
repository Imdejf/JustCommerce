using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.CommonRepositories.Notification;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkCommon
    {
        INotificationRepository Notification { get; }
        IUserNotificationRepository UserNotification { get; }
        IUserSubscriberRepository UserSubscriber { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

