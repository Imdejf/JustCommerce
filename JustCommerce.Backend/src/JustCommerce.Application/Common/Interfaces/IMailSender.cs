namespace JustCommerce.Application.Common.Interfaces
{
    public interface IMailSender
    {
        Task SendPasswordResetEmailAsync(string reciverEmail, string passwordResetToken, Guid userId, CancellationToken cancellationToken);
        Task SendEmailConfirmationEmailAsync(string reciverEmail, string emailConfirmationToken, Guid userId, CancellationToken cancellationToken);
    }
}
