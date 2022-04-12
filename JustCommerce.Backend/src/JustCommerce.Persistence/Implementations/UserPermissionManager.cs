using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces.Service;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Persistence.DataAccess;
using JustCommerce.Shared.Services.Interfaces.Permission;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.Implementations
{
    internal sealed class UserPermissionManager : IUserPermissionManager
    {
        private readonly JustCommerceDbContext _justCommerceDb;
        private readonly IPermissionsMapper _permissionsMapper;
        public UserPermissionManager(JustCommerceDbContext justCommerceDb, IPermissionsMapper permissionsMapper)
        {
            _justCommerceDb = justCommerceDb;
            _permissionsMapper = permissionsMapper;
        }

        public Task<bool> UserHasPermissionAsync(Guid userId, string permissionDomainName, int permissionFlagValue, CancellationToken cancellationToken = default)
        {
            return _justCommerceDb.UserPermission.AnyAsync(c =>
                c.UserId == userId &&
                c.PermissionDomainName == permissionDomainName &&
                c.PermissionFlagValue == permissionFlagValue
                , cancellationToken);
        }

        public async Task RemoveAllUserPermissions(Guid userId, CancellationToken cancellationToken)
        {
            var thisUserAllPermissions = await _justCommerceDb.UserPermission.AsNoTracking().Where(c => c.UserId == userId).ToListAsync(cancellationToken);
            _justCommerceDb.UserPermission.RemoveRange(thisUserAllPermissions);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task GrantUserPermissions(IEnumerable<(string, int)> permissions, Guid userId, CancellationToken cancellationToken)
        {
            var permissionsAsEntities = permissions.Select(c => UserPermissionFactory.CreateFromData(c.Item1, c.Item2, userId));
            _justCommerceDb.UserPermission.AddRange(permissionsAsEntities);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task AddPermissionAsync(UserPermissionEntity userPermission, CancellationToken cancellationToken = default)
        {
            await _justCommerceDb.UserPermission.AddAsync(userPermission, cancellationToken);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task RemovePermissionAsync(Guid userId, string permissionDomainName, int permissionFlagValue, CancellationToken cancellationToken)
        {
            var permission = await _justCommerceDb.UserPermission
                .Where(c => c.UserId == userId && c.PermissionDomainName == permissionDomainName && c.PermissionFlagValue == permissionFlagValue)
                .FirstOrDefaultAsync(cancellationToken);

            _justCommerceDb.UserPermission.Remove(permission);

            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task RemovePermissionRangeAsync(IEnumerable<PermissionDTO> permissions, Guid userId, CancellationToken cancellationToken = default)
        {
            var permissionsToRevokeAsEntities = permissions.Select(c => UserPermissionFactory.CreateFromDtoAndUserId(c, userId));
            _justCommerceDb.UserPermission.RemoveRange(permissionsToRevokeAsEntities);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task GrantPermissionRangeAsync(IEnumerable<PermissionDTO> permissions, Guid userId, CancellationToken cancellationToken = default)
        {
            var permissionsToGrantAsEntities = permissions.Select(c => UserPermissionFactory.CreateFromDtoAndUserId(c, userId));
            _justCommerceDb.UserPermission.AddRange(permissionsToGrantAsEntities);
            await _justCommerceDb.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<PermissionDTO>> GetOwnedPermissionsAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var ownedPermissions = await _justCommerceDb.UserPermission
                           .AsNoTracking()
                           .Where(c => c.UserId == userId)
                           .Select(c =>
                               PermissionDtoFactory.CreateFromData(
                                   c.PermissionDomainName,
                                   Enum.GetName(_permissionsMapper.GetPermissionTypeByName(c.PermissionDomainName), c.PermissionFlagValue),
                                   c.PermissionFlagValue)
                            )
                           .ToListAsync(cancellationToken);

            return ownedPermissions;
        }
    }
}
