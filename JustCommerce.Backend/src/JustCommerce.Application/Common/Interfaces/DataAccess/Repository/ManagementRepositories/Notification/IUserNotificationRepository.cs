using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Notification;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Notification
{
    public interface IUserNotificationRepository : IBaseRepository<UserNotificationEntity>
    {
        Task<List<UserNotificationEntity>> GetLatestNotificationAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<bool> IsBindedWithUserAsync(Guid userNotificationId, Guid userId, CancellationToken cancellationToken);
        void Complete(Guid sendNotificationId);
        void See(Guid sendNotificationId);
    }
}
