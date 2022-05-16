using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Dictionary
{
    public static class DictionaryTypeEntityFactory
    {
        public static DictionaryTypeEntity CreateFromProductCommand(CreateDictionaryType.Command command)
        {
            return new DictionaryTypeEntity
            {
                Description = command.Description,
                ShopId = command.ShopId,
                DictionaryType = command.DictionaryType,
                Name = command.Name,
            };
        }
    }
}
