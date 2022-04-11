using DataSharp.EmailSender.Implementations;
using DataSharp.EmailSender.Interfaces;
using DataSharp.EmailSender.Models;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class MailSender : IMailSender
    {
        private readonly IEmailTemplateProvider _dataSharpEmailTemplateProvider;
        private readonly MailLinksConfig _linksConfig;


        public MailSender(IEmailTemplateProvider dataSharpEmailTemplateProvider, IOptions<MailLinksConfig> linksConfig)
        {
            _dataSharpEmailTemplateProvider = dataSharpEmailTemplateProvider;
            _linksConfig ??= linksConfig?.Value;
        }
        public Task SendEmailConfirmationEmailAsync(string reciverEmail, string emailConfirmationToken, Guid userId, CancellationToken cancellationToken)
        {
            var callbackUrl = new Uri($"{_linksConfig.EmailConfirmationLink}?token={emailConfirmationToken}&UserId={userId}");

            var htmlToSend = _dataSharpEmailTemplateProvider.BuildTemplate("EmailConfirmation", reciverEmail, callbackUrl.ToString());

            var options = emailSenderConfiguration();

            IEmailSender _dataSharpEmailSender = new EmailSender(options);

            return _dataSharpEmailSender.SendAsync(c =>
                c.From(_dataSharpEmailSender.DefaultSenderAddress, _dataSharpEmailSender.DefaultSenderName)
                 .To(reciverEmail)
                 .WithBody(htmlToSend)
                 .IsBodyHtml(true)
                 .WithSubject("JustWin : Potwierdzenie adresu email")
            );
        }

        public Task SendPasswordResetEmailAsync(string reciverEmail, string passwordResetToken, Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IOptions<EmailSenderConfig> emailSenderConfiguration()
        {
            EmailSenderConfig EmailSenderConfigInstance = EmailSenderConfig.New
                .OnHost("serwer2299342.home.pl")
                .OnPort(587)
                .OnCredentials("kontakt@emagazynowo.pl", "kaHBV(.q4F")
                .WithDefaultSenderAddress("kontakt@emagazynowo.pl")
                .WithDefaultSenderDisplayName("eMagazynowo")
                .EnableSSL(false);

            IOptions<EmailSenderConfig> options = Options.Create(EmailSenderConfigInstance);

            return options;
        }
    }
}
