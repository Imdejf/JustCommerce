using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Sms
{
    public static class SmsTemplateDtoFactory
    {
        public static SmsTemplateDTO CreateFromEntity(SmsTemplateEntity entity)
        {
            return new SmsTemplateDTO
            {
                Name = entity.Name,
                SmsAccountId = entity.SmsAccountId,
                SmsType = entity.SmsType,
                SmsTemplateLang = entity.SmsTemplateLang.Select(c => SmsTemplateLangDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
