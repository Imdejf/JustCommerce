namespace JustCommerce.Application.Common.DTOs.Sms
{
    public class SmsTemplateLangDTO
    {
        public Guid SmsTemplateId { get; set; }
        public Guid LanguageId { get; set; }
        public string Text { get; set; }
    }
}
