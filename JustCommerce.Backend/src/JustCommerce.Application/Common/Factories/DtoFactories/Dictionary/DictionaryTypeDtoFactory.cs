using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Dictionary
{
    public static class DictionaryTypeDtoFactory
    {
        public static DictionaryTypeDTO CreateFromEntity(DictionaryTypeEntity entity)
        {
            return new DictionaryTypeDTO
            {
                Description = entity.Description,
                DictionaryType = entity.DictionaryType,
                Name = entity.Name,
            };
        }
    }
}
