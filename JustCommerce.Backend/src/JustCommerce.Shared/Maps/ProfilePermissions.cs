using E_Commerce.Shared.Enums.Permissions;
using E_Commerce.Shared.Models;
using JustCommerce.Shared.Enums;

namespace E_Commerce.Shared.Maps
{
    internal static class ProfilePermissions
    {
        private static IDictionary<Profile, IEnumerable<PermissionObject>> _Permissions = new Dictionary<Profile, IEnumerable<PermissionObject>>()
        {
            {
                Profile.None,
                System.Array.Empty<PermissionObject>()
            },
            {
                Profile.Accountant,
                new PermissionObject[]
                {
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangeOwnPassword.ToString(),(int)AuthServicePermissions.ChangeOwnPassword),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangePassword.ToString(),(int)AuthServicePermissions.ChangePassword),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.SetUserActiveOrDeactive.ToString(),(int)AuthServicePermissions.SetUserActiveOrDeactive),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ViewContactList.ToString(),(int)AuthServicePermissions.ViewContactList),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ViewManagementList.ToString(),(int)AuthServicePermissions.ViewManagementList),
                }
            },
            {
                Profile.Boss,
                new PermissionObject[]
                {
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangeOwnPassword.ToString(),(int)AuthServicePermissions.ChangeOwnPassword),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangePassword.ToString(),(int)AuthServicePermissions.ChangePassword),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangeRole.ToString(),(int)AuthServicePermissions.ChangeRole),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.CreateUser.ToString(),(int)AuthServicePermissions.CreateUser),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.DeleteUser.ToString(),(int)AuthServicePermissions.DeleteUser),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.EditUser.ToString(),(int)AuthServicePermissions.EditUser),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ManagePermissions.ToString(),(int)AuthServicePermissions.ManagePermissions),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.SetUserActiveOrDeactive.ToString(),(int)AuthServicePermissions.SetUserActiveOrDeactive),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ViewContactList.ToString(),(int)AuthServicePermissions.ViewContactList),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ViewManagementList.ToString(),(int)AuthServicePermissions.ViewManagementList),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.RevokePermission.ToString(),(int)AuthServicePermissions.RevokePermission),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.GrantPermission.ToString(),(int)AuthServicePermissions.GrantPermission),

                    new(typeof(ProductTypePermissions).Name,ProductTypePermissions.Create.ToString(),(int)ProductTypePermissions.Create),
                    new(typeof(ProductTypePermissions).Name,ProductTypePermissions.ViewList.ToString(),(int)ProductTypePermissions.ViewList),
                    new(typeof(ProductTypePermissions).Name,ProductTypePermissions.Delete.ToString(),(int)ProductTypePermissions.Delete),
                    new(typeof(ProductTypePermissions).Name,ProductTypePermissions.Edit.ToString(),(int)ProductTypePermissions.Edit),
                    new(typeof(ProductTypePermissions).Name,ProductTypePermissions.Detail.ToString(),(int)ProductTypePermissions.Detail),

                    new(typeof(CategoryPermissions).Name,CategoryPermissions.Create.ToString(),(int)CategoryPermissions.Create),
                    new(typeof(CategoryPermissions).Name,CategoryPermissions.ViewList.ToString(),(int)CategoryPermissions.ViewList),
                    new(typeof(CategoryPermissions).Name,CategoryPermissions.Delete.ToString(),(int)CategoryPermissions.Delete),
                    new(typeof(CategoryPermissions).Name,CategoryPermissions.Edit.ToString(),(int)CategoryPermissions.Edit),
                    new(typeof(CategoryPermissions).Name,CategoryPermissions.Detail.ToString(),(int)CategoryPermissions.Detail),

                    new(typeof(ShopPermissions).Name,ShopPermissions.Create.ToString(),(int)ShopPermissions.Create),
                    new(typeof(ShopPermissions).Name,ShopPermissions.ViewList.ToString(),(int)ShopPermissions.ViewList),
                    new(typeof(ShopPermissions).Name,ShopPermissions.Delete.ToString(),(int)ShopPermissions.Delete),
                    new(typeof(ShopPermissions).Name,ShopPermissions.Edit.ToString(),(int)ShopPermissions.Edit),
                    new(typeof(ShopPermissions).Name,ShopPermissions.Detail.ToString(),(int)ShopPermissions.Detail),
                }
            },
            {
                Profile.DeliveryManager,
                new PermissionObject[]
                {
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ChangeOwnPassword.ToString(),(int)AuthServicePermissions.ChangeOwnPassword),
                    new(typeof(AuthServicePermissions).Name,AuthServicePermissions.ViewContactList.ToString(),(int)AuthServicePermissions.ViewContactList),
                }
            },
            {
                Profile.DigitalManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.PhysicalManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.PackageManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.SettlementManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.MerchManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.Marketing,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.LicensorManager,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.NewUser,
                Array.Empty<PermissionObject>()
            },
            {
                Profile.FullUser,
                Array.Empty<PermissionObject>()
            }
        };

        public static IEnumerable<PermissionObject> GetProfilePermissions(Profile profile) => _Permissions[profile];
    }
}
