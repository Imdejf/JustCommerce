using JustCommerce.Application.Common.DTOs.Sms;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Sms
{
    public static class SmsAccountDtoFactory
    {
        public static SmsAccountDTO CreateFromEntity(SmsAccountEntity entity)
        {
            return new SmsAccountDTO
            {
                From = entity.From,
                SmsGate = entity.SmsGate,
                Test = entity.Test,
                Token = entity.Token,
                SmsTemplate = entity.SmsTemplate.Select(c => SmsTemplateDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
