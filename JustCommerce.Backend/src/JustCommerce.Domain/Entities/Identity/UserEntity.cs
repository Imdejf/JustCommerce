using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Domain.Entities.Identity
{
    public sealed class UserEntity : IdentityUser<Guid>
    {
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRegisterSource RegisterSource { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
