using JustCommerce.Application.Models.MessageBus.Abstract;

namespace JustCommerce.Application.Common.Interfaces.Notification
{
    public interface INotificationHubClientWrapper
    {
        Task SendNotification<TNotification>(TNotification notification, CancellationToken cancellationToken)
            where TNotification : BaseNotificationEvent;
    }
}
