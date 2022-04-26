using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Seeders
{
    public static class ShopSeed
    {
        public static BaseSeed<ShopEntity> BaseSeed = new BaseSeed<ShopEntity>(SeedShop);

        private static IEnumerable<ShopEntity> SeedShop => new List<ShopEntity>()
        {
            new ShopEntity("83e84e94-b1ee-4cbf-be40-daea69347600", "DataSharp", true, "Data-Sharp Dawid Jabłoński", "Karpia 22F/59", "Poznan", "Wielkopolska", "61-619","Poland","jablonskidawid0202@gmail.com"),
            new ShopEntity("6cef7328-534d-4699-98af-8779fba7d3a1", "eMagazynowo", true, "eMagazynowo Dawid Jabłoński", "Polna 7", "Przytoczna", "Lubuskie", "66-340", "Poland", "kontakt@emagazynowo.pl"),
        };

    }
}
