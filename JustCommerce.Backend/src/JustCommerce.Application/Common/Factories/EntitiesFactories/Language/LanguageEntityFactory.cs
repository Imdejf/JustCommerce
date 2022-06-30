using JustCommerce.Application.Features.ManagemenetFeatures.Language.Command;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Language
{
    public class LanguageEntityFactory
    {
        public static LanguageEntity CreateFromShopCommand(CreateLanguage.Command command)
        {
            return new LanguageEntity
            {
                NameOrginal = command.NameOrginal,
                NameInternational = command.NameInternational,
                IsoCode = command.IsoCode,
                IsActive = command.IsActive,
                ShopId = command.ShopId
            };
        }
    }
}
