using JustCommerce.Application.Common.DTOs.Language;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Language
{
    public static class LanguageDtoFactory
    {
        public static LanguageDTO CreateFromEntity(LanguageEntity language)
        {
            return new LanguageDTO
            {
                Id = language.Id,
                NameOrginal = language.NameOrginal,
                NameInternational = language.NameInternational,
                IsoCode = language.IsoCode,
                IsActive = language.IsActive,
                ShopId = language.ShopId,
                DefaultLanguage = language.DefaultLanguage
            };
        }
    }
}
