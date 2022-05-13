using JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Command;
using JustCommerce.Domain.Entities.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Email
{
    public static class EmailAccountEntityFactory
    {
        public static EmailAccountEntity CreateFromEmailAccountCommand(CreateEmailAccount.Command command)
        {
            return new EmailAccountEntity
            {
                EmailAddress = command.EmailAddress,
                Name = command.Name,
                ShopId = command.ShopId,
                SmtpLogin = command.SmtpLogin,
                SmtpPassword = command.SmtpPassword,
                SmtpProt = command.SmtpPort,
                SmtpServer = command.SmtpServer,
                ImapLogin = command.ImapLogin,
                ImapPassword = command.ImapPassword,
                ImapPort = command.ImapPort,
                ImapServer = command.ImapServer,
                Pop3Login = command.Pop3Login,
                Pop3Password = command.Pop3Password,
                Pop3Prot = command.Pop3Prot,
                Pop3Server = command.Pop3Server,
                
            };
        }
    }
}
