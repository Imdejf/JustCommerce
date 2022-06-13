using JustCommerce.Application.Common.Interfaces.Notification;
using JustCommerce.Infrastructure.Hubs.NotificationHubs;
using Microsoft.AspNetCore.SignalR;

namespace JustCommerce.Infrastructure.Implementations.Notifications
{
    public sealed class NotificationHubClient : INotificationHubClient
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHubClient(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAsync(Guid userId, string description, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.User(userId.ToString())
                                     .SendAsync("ReciveMessage", description, cancellationToken);
        }
    }
}
