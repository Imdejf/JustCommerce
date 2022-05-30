using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Notification
{
    public sealed class NotificationEntity : AuditableEntity
    {
        public NotificationType NotificationType { get; set; }
    }
}
