using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Email
{
    public static class EmailAccountDtoFactory
    {
        public static EmailAccountDTO CreateFromEntity(EmailAccountEntity emailAccount)
        {
            return new EmailAccountDTO
            {
                EmailAddress = emailAccount.EmailAddress,
                ShopId = emailAccount.ShopId,
                SmtpLogin = emailAccount.SmtpLogin,
                SmtpPassword = emailAccount.SmtpPassword,
                SmtpProt = emailAccount.SmtpPort,
                SmtpServer = emailAccount.SmtpServer,
                ImapServer = emailAccount.ImapServer,
                ImapLogin = emailAccount.ImapLogin,
                ImapPassword = emailAccount.ImapPassword,
                ImapPort = emailAccount.ImapPort,
                Pop3Login = emailAccount.Pop3Login,
                Pop3Password = emailAccount.Pop3Password,
                Pop3Prot = emailAccount.Pop3Port,
                Pop3Server = emailAccount.Pop3Server,
                Name = emailAccount.Name,
                EmailTemplate = emailAccount.EmailTemplate.Select(c => EmailTemplateDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
