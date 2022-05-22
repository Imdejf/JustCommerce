using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Seeders
{
    public static class LanguageSeed
    {
        public static BaseSeed<LanguageEntity> BaseSeed = new BaseSeed<LanguageEntity>(SeedLanguage);

        private static IEnumerable<LanguageEntity> SeedLanguage => new List<LanguageEntity>()
        {
            new LanguageEntity("b80fe531-4bb7-4f2d-a69e-86d8e20602e9", "Poland", "PL-pl", true),
            new LanguageEntity("87f0f759-323f-477d-886a-0afd7272ccd9", "English", "EN-en", false),
        };
    }
}
