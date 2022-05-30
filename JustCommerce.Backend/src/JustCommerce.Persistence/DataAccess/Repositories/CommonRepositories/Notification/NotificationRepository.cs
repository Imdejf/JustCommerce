using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.CommonRepositories.Notification;
using JustCommerce.Domain.Entities.Notification;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.Repositories.CommonRepositories.Notification
{
    internal sealed class NotificationRepository : BaseRepository<NotificationEntity>, INotificationRepository
    {
        public NotificationRepository(DbSet<NotificationEntity> entity) : base(entity)
        {
        }

        public Task<bool> ExistsAsync(NotificationType type, CancellationToken cancellationToken)
        {
            return _entity.AnyAsync(c => c.Type == type, cancellationToken);
        }
    }
}
