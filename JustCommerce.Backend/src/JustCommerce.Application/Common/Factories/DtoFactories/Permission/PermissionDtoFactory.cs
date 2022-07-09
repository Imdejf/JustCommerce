using JustCommerce.Application.Common.DTOs;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Permission
{
    public static class PermissionDtoFactory
    {
        public static PermissionDTO CreateFromData(string domainName, string flagName, int flagValue)
        {
            return new PermissionDTO
            {
                PermissionDomainName = domainName,
                PermissionFlagValue = flagValue,
                PermissionFlagName = flagName
            };
        }
    }
}
