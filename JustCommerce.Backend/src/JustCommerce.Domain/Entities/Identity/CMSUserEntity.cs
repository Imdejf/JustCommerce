using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Domain.Entities.Identity
{
    public sealed class CMSUserEntity : IdentityUser<Guid>
    {
        public Guid? SelectedShopId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string FtpPhotoFilePath { get; set; } = String.Empty;
        public UserRegisterSource RegisterSource { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Domain.Enums.Language Language { get; set; }
        public Theme Theme { get; set; }
        public Profile Profile { get; set; }
        public ICollection<UserStoreEntity> AllowedStore { get; set; } = new HashSet<UserStoreEntity>();
        public ICollection<UserPermissionEntity> UserPermissions { get; set; } = new HashSet<UserPermissionEntity>();
    }
}
