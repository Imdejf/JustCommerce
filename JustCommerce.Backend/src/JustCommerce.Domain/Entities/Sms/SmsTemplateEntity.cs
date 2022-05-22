using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Sms
{
    public sealed class SmsTemplateEntity : AuditableEntity
    {
        public Guid SmsAccountId{ get; set; }
        public SmsAccountEntity SmsAccount{ get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public string Name { get; set; }
        public SmsType SmsType { get; set; }
        public bool Active { get; set; }
        public ICollection<SmsTemplateLangEntity> SmsTemplateLang { get; set; }

        public SmsTemplateEntity()
        {

        }

        public SmsTemplateEntity(string id,string smsAccountId, string shopId, string name, SmsType smsType, bool active)
        {
            Id = Guid.Parse(id);
            SmsAccountId = Guid.Parse(smsAccountId);
            ShopId = Guid.Parse(shopId);
            Name = name;
            SmsType = smsType;
            Active = active;
        }
    }
}
