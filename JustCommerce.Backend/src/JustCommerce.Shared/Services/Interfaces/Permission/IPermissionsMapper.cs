using E_Commerce.Shared.Models;
using JustCommerce.Shared.Enums;

namespace JustCommerce.Shared.Services.Interfaces.Permission
{
    public interface IPermissionsMapper
    {
        IEnumerable<PermissionObject> GetPermissionsAsObjects();
        IEnumerable<ProfileObject> GetProfilesAsObjects();
        IEnumerable<PermissionObject> GetPermissionsByProfile(Profile profile);
        Type GetPermissionTypeByName(string name);
    }
}
