using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JustCommerce.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRegisterSource RegisterSource { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
