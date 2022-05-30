using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Notification
{
    public sealed class UserSubscribedEntity : AuditableEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
