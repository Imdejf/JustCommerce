using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Domain.Seeders
{
    public static class SmsTemplateLangSeed
    {
        public static BaseSeed<SmsTemplateLangEntity> BaseSeed = new BaseSeed<SmsTemplateLangEntity>(SeedSmsTemplateLang);

        private static IEnumerable<SmsTemplateLangEntity> SeedSmsTemplateLang => new List<SmsTemplateLangEntity>()
        {
            new SmsTemplateLangEntity("027aa12d-b89d-4993-b4f3-aa15135ebfbc", "b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "OrderCancelled PL"),
            new SmsTemplateLangEntity("027aa12d-b89d-4993-b4f3-aa15135ebfbc", "87f0f759-323f-477d-886a-0afd7272ccd9", "OrderCancelled EN"),

            new SmsTemplateLangEntity("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3", "b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "OrderInProgress PL"),
            new SmsTemplateLangEntity("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3", "87f0f759-323f-477d-886a-0afd7272ccd9", "OrderInProgress EN"),

            new SmsTemplateLangEntity("c2514d93-4e4e-4e27-bf9d-d0a77db3629b", "b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "OrderSend PL"),
            new SmsTemplateLangEntity("c2514d93-4e4e-4e27-bf9d-d0a77db3629b", "87f0f759-323f-477d-886a-0afd7272ccd9", "OrderSend EN"),

            new SmsTemplateLangEntity("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1", "b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "OrderPlaced PL"),
            new SmsTemplateLangEntity("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1", "87f0f759-323f-477d-886a-0afd7272ccd9", "OrderPlaced EN"),
        };
    }
}
