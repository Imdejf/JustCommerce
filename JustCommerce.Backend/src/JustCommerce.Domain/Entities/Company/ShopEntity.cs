using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Company
{
    public sealed class ShopEntity : AuditableEntity 
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public ICollection<UserShopEntity> AllowedUser { get; set; }
        public ICollection<EmailAccountEntity> EmailAccount { get; set; }
        public ICollection<LanguageEntity> Language { get; set; } 

        public ShopEntity() { }
        public ShopEntity(string id, string name, bool active, string fullName, string adressLine, string city, string state, string zip, string country, string email )
        {
            Id = Guid.Parse(id);
            Name = name;
            FullName = fullName;
            AddressLine = adressLine;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Email = email;
        }
    }
}