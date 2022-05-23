using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsTemplate.Query
{
    public static class GetSmsTemplateById
    {

        public sealed record Query(Guid smsTemplateId) : IRequestWrapper<SmsTemplateDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, SmsTemplateDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SmsTemplateDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var smsTemplate = await _unitOfWorkManagmenet.SmsTemplate.GetFullyObject(request.smsTemplateId, cancellationToken);

                return SmsTemplateDtoFactory.CreateFromEntity(smsTemplate);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.smsTemplateId).NotEqual(Guid.Empty);
            }
        }

    }
}
