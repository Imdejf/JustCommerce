using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Entities
{
    public sealed class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
