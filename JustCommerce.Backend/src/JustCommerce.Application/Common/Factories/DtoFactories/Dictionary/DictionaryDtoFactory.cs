using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Dictionary
{
    public static class DictionaryDtoFactory
    {
        public static DictionaryDTO CreateFromEntity(DictionaryEntity entity)
        {
            return new DictionaryDTO
            {
                DictionaryTypeId = entity.DictionaryTypeId,
                Dictionary = entity.Dictionary,
                Name = entity.Name,
                DictionaryLang = entity.DictionaryLang.Select(c => DictionaryLangDtoFactory.CreateFromEntity(c)).ToArray(),
            };
        }
    }
}
