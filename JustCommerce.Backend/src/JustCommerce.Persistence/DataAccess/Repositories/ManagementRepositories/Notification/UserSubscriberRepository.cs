using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Notification;
using JustCommerce.Domain.Entities.Notification;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Notification
{
    internal sealed class UserSubscriberRepository : BaseRepository<SubscribedUserEntity>, IUserSubscriberRepository
    {
        public UserSubscriberRepository(DbSet<SubscribedUserEntity> entity) : base(entity)
        {

        }

        public Task<List<Guid>> GetSubscribeUserIdsAsync(NotificationType notificationType, CancellationToken cancellationToken)
        {
            return _entity.Where(c => c.NotificationType == notificationType).Select(c => c.UserId).ToListAsync(cancellationToken);
        }

        public Task<bool> DoesUserSubscribeToNotificationAsync(Guid userId, NotificationType notificationType, CancellationToken cancellationToken)
        {
            return _entity.AnyAsync(c => c.UserId == userId && c.NotificationType == notificationType, cancellationToken);
        }

        public void Unsubscribe(Guid userId, NotificationType notificationType)
        {
            var localEntity = _entity.Local.Where(c => c.UserId == userId && c.NotificationType == notificationType).FirstOrDefault();
            if (localEntity == null)
            {
                var attachedEntity = _entity.Attach(new SubscribedUserEntity { NotificationType = notificationType, UserId = userId });
                attachedEntity.State = EntityState.Deleted;
            }
            else
            {
                _entity.Remove(localEntity);
            }
        }
    }
