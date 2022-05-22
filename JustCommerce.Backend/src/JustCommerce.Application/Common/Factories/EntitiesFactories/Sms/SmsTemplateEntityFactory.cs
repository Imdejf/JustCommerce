//using JustCommerce.Application.Common.DTOs.Sms;
//using JustCommerce.Domain.Entities.Sms;

//namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Sms
//{
//    public static class SmsTemplateEntityFactory
//    {
//        public static SmsTemplateEntity CreateFromDto(SmsTemplateDTO dto)
//        {
//            return new SmsTemplateEntity
//            {
//                SmsAccountId = dto.SmsAccountId,
//                SmsType = dto.SmsType,
//                Name = dto.Name,
//                SmsTemplateLang = dto.lang.Select(c => ArticleLangEntityFactory.CreateFromDto(c)).ToArray(),
//            };
//        }
//    }
//}
