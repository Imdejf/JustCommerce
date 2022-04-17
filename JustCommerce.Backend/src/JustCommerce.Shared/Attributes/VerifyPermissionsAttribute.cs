using E_Commerce.Shared.Enums;
using E_Commerce.Shared.Enums.Permissions;
using E_Commerce.Shared.Services.Implementations.PermissionMapper;
using E_Commerce.Shared.Services.Interfaces.Permission;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Commerce.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class VerifyPermissionsAttribute : Attribute, IAuthorizationFilter
    {
        public int _RequiredPermissions;
        public PermissionValidationMethod _Method;
        public Type _PermissionDomainEnumType;

        public VerifyPermissionsAttribute(AuthServicePermissions requiredPermissions, PermissionValidationMethod method) : this(requiredPermissions.GetType(), (int)requiredPermissions, method) { }
        public VerifyPermissionsAttribute(ProductTypePermissions requiredPermissions, PermissionValidationMethod method) : this(requiredPermissions.GetType(), (int)requiredPermissions, method) { }
        private VerifyPermissionsAttribute(Type type, int requiredPermissions, PermissionValidationMethod method)
        {
            _RequiredPermissions = requiredPermissions;
            _Method = method;
            _PermissionDomainEnumType = type;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];

                IPermissionValidator validator = new PermissionValidator();
                if (!validator.HasPermissions(_PermissionDomainEnumType, _RequiredPermissions, token, _Method))
                {
                    throw new UnauthorizedAccessException();
                }
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
