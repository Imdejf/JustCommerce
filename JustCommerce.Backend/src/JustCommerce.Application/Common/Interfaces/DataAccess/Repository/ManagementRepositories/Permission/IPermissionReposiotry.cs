using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Permission
{
    public interface IPermissionReposiotry : IBaseRepository<UserPermissionEntity>
    {
        Task<bool> DoesUserHavePermissionAsync(Guid userId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<bool> DoesUserHavePermissionAsync(Guid userId, string domainName, CancellationToken cancellationToken = default);
        Task<List<UserPermissionEntity>> GetAllUserPermissionsAsync(Guid userId, CancellationToken cancellationToken = default);
        Task GrantUserPermissionsAsync(IEnumerable<(string, int)> permissions, Guid userId, CancellationToken cancellationToken = default);
    }
}
