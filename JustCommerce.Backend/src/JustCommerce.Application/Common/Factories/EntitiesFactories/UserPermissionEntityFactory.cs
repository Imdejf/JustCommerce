using JustCommerce.Application.Common.DTOs;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class UserPermissionEntityFactory
    {
        public static UserPermissionEntity CreateFromDtoAndUserId(PermissionDTO dto, Guid userId)
        {
            return new UserPermissionEntity
            {
                PermissionDomainName = dto.PermissionDomainName,
                PermissionFlagValue = dto.PermissionFlagValue,
                UserId = userId
            };
        }
        public static UserPermissionEntity CreateFromData(string domainName, int flagValue, Guid userId)
        {
            return new UserPermissionEntity
            {
                PermissionDomainName = domainName,
                PermissionFlagValue = flagValue,
                UserId = userId
            };
        }
    }
}
