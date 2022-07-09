using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Email
{
    public sealed class EmailTemplateEntity : Entity
    {
        public Guid ShopId { get; set; }
        public StoreEntity Shop { get; set; }
        public Guid EmailAccountId { get; set; }
        public EmailAccountEntity EmailAccount { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public string EmailName { get; set; }
        public string Subject { get; set; } 
        public bool Active { get; set; }
        public EmailType EmailType { get; set; }

        public EmailTemplateEntity()
        {

        }

        public EmailTemplateEntity(string id, string shopId, string emailAccountId, string name, string filePath, string email,string emailName, string subject, bool active, EmailType emailType)
        {
            Id = Guid.Parse(id);
            ShopId = Guid.Parse(shopId);
            EmailAccountId = Guid.Parse(emailAccountId);
            Name = name;
            FilePath = filePath;
            Email = email;
            EmailName = emailName;
            Subject = subject;
            Active = active;
            EmailType = emailType;
        }
    }
}
