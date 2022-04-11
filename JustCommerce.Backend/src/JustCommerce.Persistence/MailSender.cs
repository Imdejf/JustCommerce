using DataSharp.EmailSender.Interfaces;
using JustCommerce.Infrastructure.Configurations;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class MailSender
    {
        private readonly IEmailSender _dataSharpEmailSender;
        private readonly IEmailTemplateProvider _dataSharpEmailTemplateProvider;
        private readonly MailLinksConfig _linksConfig;
    }
}
