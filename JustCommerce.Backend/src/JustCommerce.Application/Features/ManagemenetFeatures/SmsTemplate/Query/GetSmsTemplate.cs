using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Application.Common.Factories.DtoFactories.Sms;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsTemplate.Query
{
    public static class GetSmsTemplate
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<List<SmsTemplateDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<SmsTemplateDTO>>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagemenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagemenet)
            {
                _unitOfWorkManagemenet = unitOfWorkManagemenet;
            }

            public async Task<List<SmsTemplateDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var emailTemplateList = await _unitOfWorkManagemenet.SmsTemplate.GetAllByShopIdAsync(request.ShopId, cancellationToken);

                return emailTemplateList.Select(c => SmsTemplateDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
