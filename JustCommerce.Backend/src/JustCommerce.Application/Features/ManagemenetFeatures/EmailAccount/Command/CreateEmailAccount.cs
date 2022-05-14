using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Application.Common.Factories.DtoFactories.Email;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Email;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Command
{
    public static class CreateEmailAccount
    {

        public sealed record Command(Guid ShopId, string Name, string EmailAddress, string Pop3Server, int Pop3Prot, string Pop3Login, string Pop3Password,
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
                bool shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var newEmailAccount = EmailAccountEntityFactory.CreateFromEmailAccountCommand(request);
                newEmailAccount.CreatedBy = Guid.NewGuid().ToString();
                newEmailAccount.EmailTemplate = new List<EmailTemplateEntity>();
                await _unitOfWorkManagmenet.EmailAccount.AddAsync(newEmailAccount, cancellationToken);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return EmailAccountDtoFactory.CreateFromEntity(newEmailAccount);
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
