﻿using E_Commerce.Shared.Enums.Permissions;
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
