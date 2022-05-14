using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Application.Common.Factories.DtoFactories.Email;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Command
{
    public static class UpdateEmailAccount
    {

        public sealed record Command(Guid EmailAccountId, string Name, string EmailAddress, string Pop3Server, int Pop3Prot, string Pop3Login, string Pop3Password,
                                     string SmtpServer, int SmtpPort, string SmtpLogin, string SmtpPassword, string ImapServer, int ImapPort, string ImapLogin,
                                     string ImapPassword) : IRequestWrapper<EmailAccountDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, EmailAccountDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;

            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<EmailAccountDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var emailAccount = await _unitOfWorkManagmenet.EmailAccount.GetByIdAsync(request.EmailAccountId, cancellationToken);

                if (emailAccount is null)
                {
                    throw new EntityNotFoundException($"EmailAccount with Id : {request.EmailAccountId} doesn`t exists");
                }

                emailAccount.EmailAddress = request.EmailAddress;
                emailAccount.Name = request.Name;
                emailAccount.SmtpProt = request.SmtpPort;
                emailAccount.SmtpServer = request.SmtpServer;
                emailAccount.SmtpPassword = request.SmtpPassword;
                emailAccount.SmtpLogin = request.SmtpLogin;
                emailAccount.Pop3Login = request.Pop3Login;
                emailAccount.Pop3Password = request.Pop3Password;
                emailAccount.Pop3Prot = request.Pop3Prot;
                emailAccount.Pop3Server = request.Pop3Server;
                emailAccount.ImapPort = request.ImapPort;
                emailAccount.ImapLogin = request.ImapLogin;
                emailAccount.ImapPassword = request.ImapPassword;
                emailAccount.ImapServer = request.ImapServer;

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);
               
                return EmailAccountDtoFactory.CreateFromEntity(emailAccount);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }

    }
}
