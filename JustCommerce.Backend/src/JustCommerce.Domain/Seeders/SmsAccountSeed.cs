using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Seeders
{
    public static class SmsAccountSeed
    {
        public static BaseSeed<SmsAccountEntity> BaseSeed = new BaseSeed<SmsAccountEntity>(SeedSmsAccount);

        private static IEnumerable<SmsAccountEntity> SeedSmsAccount => new List<SmsAccountEntity>()
        {
            new SmsAccountEntity("2bbfc7c9-8c9c-4f53-82ef-f7560a463070","6cef7328-534d-4699-98af-8779fba7d3a1",Enums.SmsGate.SmsApi, "Test", "te", false),
        };
    }
}
