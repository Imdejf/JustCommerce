using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Sms;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsTemplate.Command
{
    public static class UpdateSmsTemplate
    {

        public sealed record Command(Guid SmsTemplateId, string Name, SmsType SmsType, bool Active, ICollection<SmsTemplateLangDTO> SmsTemplateLang) : IRequestWrapper<SmsTemplateDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, SmsTemplateDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsTemplateDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var smsTemplate = await _unitOfWorkManagmenet.SmsTemplate.GetFullyObject(request.SmsTemplateId, cancellationToken);

                if(smsTemplate is null)
                {
                    throw new EntityNotFoundException($"SmsTemplate with Id : {request.SmsTemplateId} doesn`t exists");
                }

                smsTemplate.Name = request.Name;
                smsTemplate.SmsType = request.SmsType;
                smsTemplate.Active = request.Active;

                foreach (var lang in smsTemplate.SmsTemplateLang)
                {
                    var newLang = request.SmsTemplateLang.Where(c => c.LanguageId == lang.Language.Id).FirstOrDefault();
                    if (newLang != null)
                    {
                        lang.Text = newLang.Text;
                    }
                    else
                    {
                        var addLang = SmsTemplateLangEntityFacotry.CreateFromDto(newLang);
                        smsTemplate.SmsTemplateLang.Add(addLang);
                    }
                }

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return SmsTemplateDtoFactory.CreateFromEntity(smsTemplate);

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
