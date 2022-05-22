using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Seeders
{
    public static class SmsTemplateSeed
    {
        public static BaseSeed<SmsTemplateEntity> BaseSeed = new BaseSeed<SmsTemplateEntity>(SeedSmsTemplate);

        private static IEnumerable<SmsTemplateEntity> SeedSmsTemplate => new List<SmsTemplateEntity>()
        {
            new SmsTemplateEntity("027aa12d-b89d-4993-b4f3-aa15135ebfbc","2bbfc7c9-8c9c-4f53-82ef-f7560a463070","6cef7328-534d-4699-98af-8779fba7d3a1", "OrderCancelled", Enums.SmsType.OrderCancelled, true),
            new SmsTemplateEntity("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3","2bbfc7c9-8c9c-4f53-82ef-f7560a463070","6cef7328-534d-4699-98af-8779fba7d3a1", "OrderInProgress", Enums.SmsType.OrderInProgress, true),
            new SmsTemplateEntity("c2514d93-4e4e-4e27-bf9d-d0a77db3629b","2bbfc7c9-8c9c-4f53-82ef-f7560a463070","6cef7328-534d-4699-98af-8779fba7d3a1", "OrderSend", Enums.SmsType.OrderSend, true),
            new SmsTemplateEntity("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1","2bbfc7c9-8c9c-4f53-82ef-f7560a463070","6cef7328-534d-4699-98af-8779fba7d3a1", "OrderPlaced", Enums.SmsType.OrderPlaced, true),
        };
    }
}
