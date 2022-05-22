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
        public int? Pop3Port { get; set; }
        public string? Pop3Login { get; set; }
        public string? Pop3Password { get; set; }
        public string? SmtpServer { get; set; }
        public int? SmtpPort { get; set; }
        public string? SmtpLogin { get; set; }
        public string? SmtpPassword { get; set; }
        public string? ImapServer { get; set; }
        public int? ImapPort { get; set; }
        public string? ImapLogin { get; set; }
        public string? ImapPassword { get; set; }

        public EmailAccountEntity() { }

        public EmailAccountEntity(string id,string shopId, string? name, string? emailAdress, string? pop3Server, int? pop3Port, string? pop3Login, string? pop3Password, string? smtpServer, int? smtpPort, string? smtpLogin, string? smtpPassword,
                                  string? imapServer, int? imapPort, string? imapLogin, string? imapPassword)
        {
            Id = Guid.Parse(id);
            ShopId = Guid.Parse(shopId);
            Name = name;
            EmailAddress = emailAdress;
            Pop3Server = pop3Server;
            Pop3Port = pop3Port;
            Pop3Password = pop3Password;
            Pop3Login = Pop3Login;
            SmtpServer = smtpServer;
            SmtpPort = smtpPort;
            SmtpLogin = smtpLogin;
            SmtpPassword = smtpPassword;
            ImapServer = imapServer;
            ImapPort = imapPort;
            ImapLogin = imapLogin;
            ImapPassword = imapPassword;
        }
    }
}
