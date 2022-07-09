using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Identity
{
    public sealed class UserPermissionEntity : Entity
    {
        public Guid UserId { get; set; }
        public CMSUserEntity User { get; set; } = new CMSUserEntity();
        public string PermissionDomainName { get; set; } = String.Empty;
        public int PermissionFlagValue { get; set; }
    }
}
