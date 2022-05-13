using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Email
{
    public static class EmailAccountDtoFactory
    {
        public static EmailAccountDTO CreateFromEntity(EmailAccountEntity language)
        {
            return new EmailAccountDTO
            {
                EmailAddress = language.EmailAddress,
                ShopId = language.ShopId,
                SmtpLogin = language.SmtpLogin,
                SmtpPassword = language.SmtpPassword,
                SmtpProt = language.SmtpProt,
                SmtpServer = language.SmtpServer,
                ImapServer = language.ImapServer,
                ImapLogin = language.ImapLogin,
                ImapPassword = language.ImapPassword,
                ImapPort = language.ImapPort,
                Pop3Login = language.Pop3Login,
                Pop3Password = language.Pop3Password,
                Pop3Prot = language.Pop3Prot,
                Pop3Server = language.Pop3Server,
                Name = language.Name,
                EmailTemplate = language.EmailTemplate.Select(c => EmailTemplateDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
