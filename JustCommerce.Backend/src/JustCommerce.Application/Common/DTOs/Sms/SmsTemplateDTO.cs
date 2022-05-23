using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.DTOs.Sms
{
    public class SmsTemplateDTO
    {
        public Guid ShopId { get; set; }
        public Guid SmsAccountId { get; set; }
        public string Name { get; set; }
        public SmsType SmsType { get; set; }
        public bool Active { get; set; }
        public ICollection<SmsTemplateLangDTO> SmsTemplateLang { get; set; }

    }
}
