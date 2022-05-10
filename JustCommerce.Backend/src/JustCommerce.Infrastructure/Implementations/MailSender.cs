﻿using DataSharp.EmailSender.Implementations;
using DataSharp.EmailSender.Interfaces;
using DataSharp.EmailSender.Models;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Infrastructure.Configurations;
using JustCommerce.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class MailSender : IMailSender
    {
        private readonly IEmailTemplateProvider _dataSharpEmailTemplateProvider;
        private readonly MailLinksConfig _linksConfig;
        private readonly JustCommerceDbContext _justCommerceDbContext;

        public MailSender(IEmailTemplateProvider dataSharpEmailTemplateProvider, IOptions<MailLinksConfig> linksConfig, JustCommerceDbContext justCommerceDbContext)
        {
            _dataSharpEmailTemplateProvider = dataSharpEmailTemplateProvider;
            _linksConfig ??= linksConfig?.Value;
            _justCommerceDbContext = justCommerceDbContext;
        }
        public async Task SendEmailConfirmationEmailAsync(string reciverEmail, string emailConfirmationToken, Guid userId, Guid shopId, EmailType emailType, CancellationToken cancellationToken = default)
        {
            var callbackUrl = new Uri($"{_linksConfig.EmailConfirmationLink}?token={emailConfirmationToken}&UserId={userId}");

            var htmlToSend = _dataSharpEmailTemplateProvider.BuildTemplate("EmailConfirmation", reciverEmail, callbackUrl.ToString());

            var emailTemplate = await _justCommerceDbContext.EmailTemplate.Where(c => c.EmailType == emailType && c.ShopId == shopId).FirstAsync();

            var options = emailSenderConfiguration(emailTemplate.EmailAccount.ImapServer, emailTemplate.EmailAccount.ImapPort, emailTemplate.EmailAccount.ImapLogin,
                                                   emailTemplate.EmailAccount.ImapPassword, emailTemplate.EmailAccount.EmailAddress, emailTemplate.EmailAccount.Name, true);

            IEmailSender _dataSharpEmailSender = new EmailSender(options);

            await _dataSharpEmailSender.SendAsync(c =>
                c.From(_dataSharpEmailSender.DefaultSenderAddress, _dataSharpEmailSender.DefaultSenderName)
                 .To(reciverEmail)
                 .WithBody(htmlToSend)
                 .IsBodyHtml(true)
                 .WithSubject("eMagazynowo : Potwierdzenie adresu email")
            );
        }

        public async Task SendEmailOfferAsync(string reciverEmail, Guid shopId, EmailType emailType, string offerNumber,byte[] offerAttachment, CancellationToken cancellationToken = default)
        {
            var htmlToSend = _dataSharpEmailTemplateProvider.BuildTemplate("Offer");

            var emailTemplate = await _justCommerceDbContext.EmailTemplate.Include(c => c.EmailAccount).Where(c => c.EmailType == emailType && c.ShopId == shopId).FirstAsync();

            var options = emailSenderConfiguration(emailTemplate.EmailAccount.SmtpServer, emailTemplate.EmailAccount.SmtpProt, emailTemplate.EmailAccount.SmtpLogin,
                                                   emailTemplate.EmailAccount.SmtpPassword, emailTemplate.EmailAccount.EmailAddress, emailTemplate.EmailAccount.Name, true);

            Attachment att = new Attachment(new MemoryStream(offerAttachment), $"{offerNumber}.pdf");

            IEmailSender _dataSharpEmailSender = new EmailSender(options);

            await _dataSharpEmailSender.SendAsync(c =>
                c.From(_dataSharpEmailSender.DefaultSenderAddress, _dataSharpEmailSender.DefaultSenderName)
                 .To(reciverEmail)
                 .WithBody(htmlToSend)
                 .IsBodyHtml(true)
                 .WithAttachment(att)
                 .WithSubject("eMagazynowo : Oferta handlowa"));
        }

        public async Task SendPasswordResetEmailAsync(string reciverEmail, string passwordResetToken, Guid userId, Guid shopId, EmailType emailType, CancellationToken cancellationToken = default)
        {
            var callbackUrl = new Uri($"{_linksConfig.PasswordResetLink}?token={passwordResetToken}&UserId={userId}");

            var htmlToSend = _dataSharpEmailTemplateProvider.BuildTemplate("PasswordReset", reciverEmail, callbackUrl.ToString());

            var emailTemplate = await _justCommerceDbContext.EmailTemplate.Include(c => c.EmailAccount).Where(c => c.EmailType == emailType && c.ShopId == shopId).FirstAsync();

            var options = emailSenderConfiguration(emailTemplate.EmailAccount.SmtpServer, emailTemplate.EmailAccount.SmtpProt, emailTemplate.EmailAccount.SmtpLogin,
                                                   emailTemplate.EmailAccount.SmtpPassword, emailTemplate.EmailAccount.EmailAddress, emailTemplate.EmailAccount.Name, true);

            IEmailSender _dataSharpEmailSender = new EmailSender(options);

            await _dataSharpEmailSender.SendAsync(c =>
                c.From(_dataSharpEmailSender.DefaultSenderAddress, _dataSharpEmailSender.DefaultSenderName)
                 .To(reciverEmail)
                 .WithBody(htmlToSend)
                 .IsBodyHtml(true)
                 .WithSubject("eMagazynowo : Resetowanie hasła")
            );
        }

        private IOptions<EmailSenderConfig> emailSenderConfiguration(string host, int? port, string login, string password, string defualtEmail, string defualtName, bool ssl)
        {
            EmailSenderConfig EmailSenderConfigInstance = EmailSenderConfig.New
                .OnHost(host)
                .OnPort(port.GetValueOrDefault())
                .OnCredentials(login, password)
                .WithDefaultSenderAddress(defualtEmail)
                .WithDefaultSenderDisplayName(defualtName)
                .EnableSSL(ssl);

            IOptions<EmailSenderConfig> options = Options.Create(EmailSenderConfigInstance);

            return options;
        }
    }
}
