using JustCommerce.Application.Common.Interfaces.Notification;
using JustCommerce.Infrastructure.Implementations.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace JustCommerce.Infrastructure.Hubs.NotificationHubs
{
    [Authorize]
    public sealed class NotificationHub : Hub<INotificationHubClient>
    {
        private readonly UserIdsManager _userIdsManager;
        public NotificationHub(UserIdsManager userIdsManager)
        {
            _userIdsManager = userIdsManager;
        }

        public override Task OnConnectedAsync()
        {
            _userIdsManager.Add(Context.ConnectionId, Context.UserIdentifier);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _userIdsManager.RemoveByConnectionId(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}