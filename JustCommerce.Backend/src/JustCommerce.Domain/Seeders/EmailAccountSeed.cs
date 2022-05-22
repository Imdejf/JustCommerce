using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Domain.Seeders
{
    public class EmailAccountSeed
    {
        public static BaseSeed<EmailAccountEntity> BaseSeed = new BaseSeed<EmailAccountEntity>(SeedEmailAccount);

        private static IEnumerable<EmailAccountEntity> SeedEmailAccount => new List<EmailAccountEntity>()
        {
            new EmailAccountEntity("014e3b4b-e2a7-4499-8c82-a905b7b086e2","6cef7328-534d-4699-98af-8779fba7d3a1", "Ogolne","kontakt@emagazynowo.pl","",1,"","","",1,"","","serwer2299342.home.pl",143,"kontakt@emagazynowo.pl", "kaHBV(.q4F")
        };
    }
}
