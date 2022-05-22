using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.DTOs.Sms
{
    public class SmsAccountDTO
    {
        public SmsGate SmsGate { get; set; }
        public string From { get; set; } = String.Empty;
        public string? Token { get; set; }
        public bool Test { get; set; }
        public ICollection<SmsTemplateDTO>? SmsTemplate { get; set; }
    }
}
