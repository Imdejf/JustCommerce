using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Permission;
using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Permission
{
    internal sealed class PermissionRepository : BaseRepository<UserPermissionEntity>, IPermissionReposiotry
    {
        public PermissionRepository(DbSet<UserPermissionEntity> entity) : base(entity) { }

        public async Task GrantUserPermissionsAsync(IEnumerable<(string, int)> permissions, Guid userId, CancellationToken cancellationToken = default)
        {
            var permissionEntities = permissions.Select(c => new UserPermissionEntity { PermissionDomainName = c.Item1, PermissionFlagValue = c.Item2, UserId = userId });
            await _entity.AddRangeAsync(permissionEntities);
        }

        public Task<List<UserPermissionEntity>> GetAllUserPermissionsAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.UserId == userId).ToListAsync(cancellationToken);
        }

        public Task<bool> DoesUserHavePermissionAsync(Guid userId, Guid permissionId, CancellationToken cancellationToken = default)
        {
            return _entity.AnyAsync(c => c.UserId == userId && c.Id == permissionId, cancellationToken);
        }

        public Task<bool> DoesUserHavePermissionAsync(Guid userId, string domainName, CancellationToken cancellationToken = default)
        {
            return _entity.AnyAsync(c => c.PermissionDomainName == domainName && c.UserId == userId, cancellationToken);
        }
    }
}
