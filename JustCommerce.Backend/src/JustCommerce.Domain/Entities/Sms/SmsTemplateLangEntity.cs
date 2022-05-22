using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Sms
{
    public sealed class SmsTemplateLangEntity
    {
        public Guid SmsTemplateId { get; set; }
        public SmsTemplateEntity SmsTemplate { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Text { get; set; }

        public SmsTemplateLangEntity()
        {

        }

        public SmsTemplateLangEntity(string smsTemplateId, string languageId, string text)
        {
            SmsTemplateId = Guid.Parse(smsTemplateId);
            LanguageId = Guid.Parse(languageId);
            Text = text;
        }
    }
}
