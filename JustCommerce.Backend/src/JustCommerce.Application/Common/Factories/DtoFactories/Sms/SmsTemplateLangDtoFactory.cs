using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Sms
{
    public static class SmsTemplateLangDtoFactory
    {
        public static SmsTemplateLangDTO CreateFromEntity(SmsTemplateLangEntity entity)
        {
            return new SmsTemplateLangDTO
            {
                SmsTemplateId = entity.SmsTemplateId,
                LanguageId = entity.LanguageId,
                Text = entity.Text,
            };
        }
    }
}
