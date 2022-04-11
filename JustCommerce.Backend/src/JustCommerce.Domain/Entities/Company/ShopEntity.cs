using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Domain.Entities.Company
{
    public sealed class ShopEntity : AuditableEntity 
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string FullName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public ICollection<UserEntity> User { get; set; }
        public ICollection<EmailAccountEntity> EmailAccount { get; set; }
    }
}