using JustCommerce.Application.Common.DTOs;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Identity
{
    public static class UserPermissionsDtoFactory
    {
        public static UserPermissionsDTO CreateFromData(Guid userId, IEnumerable<PermissionDTO> owned, IEnumerable<PermissionDTO> unowned)
        {
            return new UserPermissionsDTO
            {
                UserId = userId,
                Permission = owned.Select(c => new Tuple<PermissionDTO, bool>(c, true)).Union(unowned.Select(a => new Tuple<PermissionDTO, bool>(a, false))).ToArray()
            };
        }
    }
}
