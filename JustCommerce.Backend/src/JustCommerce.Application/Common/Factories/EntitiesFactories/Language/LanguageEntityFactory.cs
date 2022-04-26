using JustCommerce.Application.Features.ManagemenetFeatures.Language.Command;
using JustCommerce.Domain.Entities.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Language
{
    public class LanguageEntityFactory
    {
        public static LanguageEntity CreateFromShopCommand(CreateLanguage.Command command)
        {
            return new LanguageEntity
            {
                Name = command.Name,
                IsoCode = command.IsoCode,
            };
        }
    }
}
