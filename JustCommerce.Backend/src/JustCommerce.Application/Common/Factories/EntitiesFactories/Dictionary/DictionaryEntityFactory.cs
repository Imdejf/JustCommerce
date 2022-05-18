using JustCommerce.Application.Features.ManagemenetFeatures.Dictionary.Command;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Dictionary
{
    public static class DictionaryEntityFactory
    {
        public static DictionaryEntity CreateFromCommand(CreateDictionary.Command command)
        {
            return new DictionaryEntity
            {
                Dictionary = command.Dictionary,
                DictionaryTypeId = command.DictionaryTypeId,
                Name = command.Name,
                DictionaryLang = command.DictionaryLang.Select(c => DictionaryLangEntityFactory.CreateFromDictionaryCommand(c)).ToArray(),
            };
        }
    }
}
