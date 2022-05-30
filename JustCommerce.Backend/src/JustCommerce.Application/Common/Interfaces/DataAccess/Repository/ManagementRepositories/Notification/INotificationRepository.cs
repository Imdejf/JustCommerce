using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Notification
{
    public interface INotificationRepository
    {
        Task<bool> ExistsAsync(NotificationType type, CancellationToken cancellationToken = default);
    }
}
