using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Seeders
{
    public static class LanguageSeed
    {
        public static BaseSeed<LanguageEntity> BaseSeed = new BaseSeed<LanguageEntity>(SeedLanguage);

        private static IEnumerable<LanguageEntity> SeedLanguage => new List<LanguageEntity>()
        {
            new LanguageEntity("b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "Polski", "PL-pl", "Polish", true, true,"6cef7328-534d-4699-98af-8779fba7d3a1"),
            new LanguageEntity("87f0f759-323f-477d-886a-0afd7272ccd9", "English", "EN-en", "English", true, false,"6cef7328-534d-4699-98af-8779fba7d3a1"),
            new LanguageEntity("cce919b8-3a08-417f-8eec-cac0b3fa3b31", "Polski", "PL-pl", "Polish", true, true,"83e84e94-b1ee-4cbf-be40-daea69347600"),
            new LanguageEntity("42f64f81-7935-4724-beb4-edc5f6033868", "English", "EN-en", "English", true, false,"83e84e94-b1ee-4cbf-be40-daea69347600"),
        };
    }
}
