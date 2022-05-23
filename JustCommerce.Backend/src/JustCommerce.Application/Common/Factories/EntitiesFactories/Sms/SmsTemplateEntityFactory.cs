using JustCommerce.Application.Features.ManagemenetFeatures.EmailTemplate.Command;
using JustCommerce.Application.Features.ManagemenetFeatures.SmsTemplate.Command;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Sms
{
    public static class SmsTemplateEntityFactory
    {
        public static SmsTemplateEntity CreateFromCommand(CreateSmsTemplate.Command command)
        {
            return new SmsTemplateEntity
            {
                ShopId = command.ShopId,
                SmsAccountId = command.SmsAccountId,
                SmsType = command.SmsType,
                Active = command.Active,
                SmsTemplateLang = command.SmsTemplateLang.Select(c => SmsTemplateLangEntityFacotry.CreateFromDto(c)).ToArray(),
            };
        }
    }
}
