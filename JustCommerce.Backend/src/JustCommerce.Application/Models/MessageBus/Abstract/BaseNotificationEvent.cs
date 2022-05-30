using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Models.MessageBus.Abstract
{
    public abstract class BaseNotificationEvent
    {
        public abstract NotificationType NotificationType { get; }
        protected abstract string _Description { get; }
        public abstract string GetDescription();
    }
}
