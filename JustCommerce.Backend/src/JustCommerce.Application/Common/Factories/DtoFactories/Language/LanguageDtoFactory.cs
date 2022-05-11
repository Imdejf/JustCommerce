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
                Name = language.Name,
                IsoCode = language.IsoCode,
            };
        }
    }
}
