using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Dictionary
{
    public static class DictionaryLangDtoFactory
    {
        public static DictionaryLangDTO CreateFromEntity(DictionaryLangEntity entity)
        {
            return new DictionaryLangDTO
            {
                DictionaryId = entity.DictionaryId,
                LanguageId = entity.LanguageId,
                Text = entity.Text,
            };
        }
    }
}
