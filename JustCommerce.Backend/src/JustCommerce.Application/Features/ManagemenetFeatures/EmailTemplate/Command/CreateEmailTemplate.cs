using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Application.Common.DTOs.FileTemplate;
using JustCommerce.Application.Common.Factories.DtoFactories.Email;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Email;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.EmailTemplate.Command
{
    public static class CreateEmailTemplate
    {

        public sealed record Command(Guid ShopId, Guid EmailAccountId, string Name, string Email, string EmailName, string Subject, bool Active,
                                     EmailType EmailType, FileTemplateDTO FileTemplate) : IRequestWrapper<EmailTemplateDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, EmailTemplateDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<EmailTemplateDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var emailTypeExist = await _unitOfWorkManagmenet.EmailTemplate.ExistEmailTypeAsync(request.ShopId, request.EmailType, cancellationToken);

                if (emailTypeExist)
                {
                    throw new InvalidRequestException($"EmailTemplate by type: {request.EmailType.ToString()} exist");
                }

                var shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var emailAccountExist = await _unitOfWorkManagmenet.EmailAccount.ExistsAsync(request.EmailAccountId, cancellationToken);

                if (!emailAccountExist)
                {
                    throw new EntityNotFoundException($"EmailAccount with Id : {request.EmailAccountId} doesn`t exists");
                }

                var newEmailTemplate = EmailTemplateEntityFactory.CreateFromEmailTemplateCommand(request);

                string emailTemplatePath = Directory.GetCurrentDirectory().Split("bin")[0] + $@"\Templates\EmailTemplates\{request.ShopId}";

                if (!Directory.Exists(emailTemplatePath))
                {
                    Directory.CreateDirectory(emailTemplatePath);
                }


                if (request.FileTemplate.Base64File != null)
                {
                    byte[] emailTemplateByte = Convert.FromBase64String(request.FileTemplate.Base64File.Base64String);
                    File.WriteAllBytes(emailTemplatePath + @$"\{request.EmailType.ToString()}.html", emailTemplateByte);
                }
                else
                {
                    File.WriteAllText(emailTemplatePath + @$"\{request.EmailType.ToString()}.html", request.FileTemplate.HtmlTemplate);
                }

                newEmailTemplate.FilePath = emailTemplatePath + @$"\{request.EmailType.ToString()}.html";
                newEmailTemplate.CreatedBy = Guid.NewGuid().ToString();
                newEmailTemplate.Id = Guid.NewGuid();
                newEmailTemplate.CreatedDate = DateTime.Now;

                var entity = new EmailTemplateEntity()
                {
                    Active = true,
                    ShopId = Guid.Parse("6cef7328-534d-4699-98af-8779fba7d3a1"),
                    Subject = "test",
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    EmailAccountId = Guid.Parse("8091556d-7c69-4122-a3e9-08da3524bf3f"),
                    EmailName = "test",
                    FilePath = "test",
                    Name = "test",
                    Email = "test",
                    Id = Guid.NewGuid(),
                    EmailType = EmailType.Register,

                };

                await _unitOfWorkManagmenet.EmailTemplate.AddAsync(entity, cancellationToken);

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);


                //await _unitOfWorkManagmenet.EmailTemplate.AddAsync(newEmailTemplate, cancellationToken);
                //try
                //{

                //await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);
                //}
                //catch(TaskCanceledException ex)
                //{
                //    throw new TaskCanceledException();
                //}


                return EmailTemplateDtoFactory.CreateFromEntity(newEmailTemplate);
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
