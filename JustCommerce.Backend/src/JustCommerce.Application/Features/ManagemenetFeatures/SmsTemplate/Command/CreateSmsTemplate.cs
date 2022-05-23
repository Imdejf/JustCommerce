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
    public static class CreateSmsTemplate
    {

        public sealed record Command(Guid SmsAccountId, Guid ShopId, string Name, SmsType SmsType, bool Active, ICollection<SmsTemplateLangDTO> SmsTemplateLang) : IRequestWrapper<SmsTemplateDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, SmsTemplateDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsTemplateDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var smsAccountExsit = await _unitOfWorkManagmenet.SmsAccount.ExistsAsync(request.SmsAccountId, cancellationToken);

                if (!smsAccountExsit)
                {
                    throw new EntityNotFoundException($"SmsAccount with Id : {request.SmsAccountId} doesn`t exists");
                }

                var shopExist = _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (shopExist is null)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var createSmsTemplate = SmsTemplateEntityFactory.CreateFromCommand(request);

                await _unitOfWorkManagmenet.SmsTemplate.AddAsync(createSmsTemplate, cancellationToken);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return SmsTemplateDtoFactory.CreateFromEntity(createSmsTemplate);
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
