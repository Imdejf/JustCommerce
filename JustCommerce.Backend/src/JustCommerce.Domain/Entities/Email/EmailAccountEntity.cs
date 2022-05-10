using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Email
{
    public sealed class EmailAccountEntity : AuditableEntity
    {
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public ICollection<EmailTemplateEntity> EmailTemplate { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Pop3Server { get; set; }
        public int? Pop3Prot { get; set; }
        public string? Pop3Login { get; set; }
        public string? Pop3Password { get; set; }
        public string? SmtpServer { get; set; }
        public int? SmtpProt { get; set; }
        public string? SmtpLogin { get; set; }
        public string? SmtpPassword { get; set; }
        public string? ImapServer { get; set; }
        public int? ImapPort { get; set; }
        public string? ImapLogin { get; set; }
        public string? ImapPassword { get; set; }
    }
}
