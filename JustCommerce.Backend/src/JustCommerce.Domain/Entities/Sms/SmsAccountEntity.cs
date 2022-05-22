using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Sms
{
    public class SmsAccountEntity : AuditableEntity
    {
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public SmsGate SmsGate { get; set; }
        public string From { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public bool Test { get; set; }
        public ICollection<SmsTemplateEntity>? SmsTemplate { get; set; }

        public SmsAccountEntity()
        {

        }

        public SmsAccountEntity(string id, string shopId, SmsGate smsGate, string from, string token, bool test)
        {
            Id = Guid.Parse(id);
            ShopId = Guid.Parse(shopId);
            SmsGate = smsGate;
            From = from;
            Token = token;
            Test = test;
        }
    }
}
