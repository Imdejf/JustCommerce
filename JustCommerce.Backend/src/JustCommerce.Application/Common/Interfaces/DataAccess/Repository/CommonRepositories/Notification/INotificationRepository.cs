using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.CommonRepositories.Notification
{
    public interface INotificationRepository
    {
        Task<bool> ExistsAsync(NotificationType type, CancellationToken cancellationToken = default);
    }
}
