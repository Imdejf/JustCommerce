using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.CommonRepositories.Notification;
using JustCommerce.Domain.Entities.Notification;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.CommonRepositories.Notification
{
    internal sealed class NotificationRepository : BaseRepository<NotificationEntity>, INotificationRepository
    {
        public NotificationRepository(DbSet<NotificationEntity> entity) : base(entity)
        {
        }

        public Task<bool> ExistsAsync(NotificationType type, CancellationToken cancellationToken)
        {
            return _entity.AnyAsync(c => c.NotificationType == type, cancellationToken);
        }
    }
}
