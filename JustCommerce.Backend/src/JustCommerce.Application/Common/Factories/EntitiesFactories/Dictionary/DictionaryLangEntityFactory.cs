using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Dictionary
{
    public static class DictionaryLangEntityFactory
    {
        public static DictionaryLangEntity CreateFromProductCommand(DictionaryLangDTO lang)
        {
            return new DictionaryLangEntity
            {
                DictionaryId = lang.DictionaryId,
                LanguageId = lang.LanguageId,
                Text = lang.Text,
            };
        }
    }
}
