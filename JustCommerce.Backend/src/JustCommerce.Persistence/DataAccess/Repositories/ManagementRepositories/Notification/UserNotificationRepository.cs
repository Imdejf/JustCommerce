using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Notification;
using JustCommerce.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Notification
{
    internal sealed class UserNotificationRepository : BaseRepository<UserNotificationEntity>, IUserNotificationRepository
    {
        public UserNotificationRepository(DbSet<UserNotificationEntity> entity) : base(entity)
        {
        }

        public void Complete(Guid sendNotificationId)
        {
            var attachedEntity = _entity.Attach(new UserNotificationEntity { Id = sendNotificationId });
            attachedEntity.Entity.Completed = true;
        }

        public Task<bool> IsBindedWithUserAsync(Guid userNotificationId, Guid userId, CancellationToken cancellationToken)
        {
            return _entity.AnyAsync(c => c.Id == userNotificationId && c.UserId == userId, cancellationToken);
        }

        public void See(Guid sendNotificationId)
        {
            var attachedEntity = _entity.Attach(new UserNotificationEntity { Id = sendNotificationId });
            attachedEntity.Entity.Seen = true;
        }

        public Task<List<UserNotificationEntity>> GetLatestNotificationAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _entity.OrderBy(c => c.CreationDate)
                          .Where(c => c.UserId == userId)
                          .Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize)
                          .ToListAsync(cancellationToken);
        }
    }
