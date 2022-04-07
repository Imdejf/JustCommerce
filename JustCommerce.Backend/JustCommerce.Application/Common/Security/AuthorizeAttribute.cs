using JustCommerce.Application.Common.Exceptions;
using JustCommerce.Application.Common.Interfaces.CommonFeatures;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JustCommerce.Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Roles> _roles;

        public AuthorizeAttribute(params Roles[] roles)
        {
            _roles = roles ?? new Roles[] { };
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            //// authorization
            var currentUser = context.HttpContext.RequestServices.GetService(typeof(ICurrentUserService)) as ICurrentUserService;
            var userManager = context.HttpContext.RequestServices.GetService(typeof(IUserManager)) as IUserManager;
            //    // Must be authenticated user
            if (currentUser?.CurrentUser == null || currentUser.CurrentUser.Id == Guid.Empty)
            {
                throw new UnauthorizedAccessException();
            }

            // Role-based authorization
            if (_roles.Any())
            {
                var authorized = false;
                foreach (var role in _roles)
                {
                    var isInRole = await userManager!.IsInRoleAsync(currentUser.CurrentUser.Id, role.ToString());
                    if (isInRole)
                    {
                        authorized = true;
                        break;
                    }
                }
                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            //Role-claimed authorization


            // Policy-based authorization
            //var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
            //if (authorizeAttributesWithPolicies.Any())
            //{
            //    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
            //    {
            //        var authorized = await _identityService.AuthorizeAsync(_currentUserService.UserId, policy);

            //        if (!authorized)
            //        {
            //            throw new ForbiddenAccessException();
            //        }
            //    }
            //}

            // User is authorized / authorization not required
        }
    }
}