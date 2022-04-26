using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Domain.Seeders
{
    public static class ProductTypeSeed
    {
        public static BaseSeed<ProductTypeEntity> BaseSeed = new BaseSeed<ProductTypeEntity>(SeedProductType);

        private static IEnumerable<ProductTypeEntity> SeedProductType => new List<ProductTypeEntity>()
        {
            new ProductTypeEntity("8539176a-3578-48e1-a2d7-3cce1389c762","6cef7328-534d-4699-98af-8779fba7d3a1", "Pojemniki"),
            new ProductTypeEntity("371b379b-3ff4-4523-bd15-b545e185b97c","6cef7328-534d-4699-98af-8779fba7d3a1", "Regały"),
            new ProductTypeEntity("d13b4109-2acd-46f5-bd8b-d7f789fac0e0","83e84e94-b1ee-4cbf-be40-daea69347600", "Maty"),
            new ProductTypeEntity("e8d5076f-7501-4bb7-8581-f7f894d7a879","83e84e94-b1ee-4cbf-be40-daea69347600", "Drzwi"),
        };
    }
}
