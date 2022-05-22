using JustCommerce.Application.Features.ManagemenetFeatures.SmsAccount.Command;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Sms
{
    public static class SmsAccountEntityFactory
    {
        public static SmsAccountEntity CreateFromCommand(CreateSmsAccount.Command command)
        {
            return new SmsAccountEntity
            {
                ShopId = command.ShopId,
                From = command.From,
                SmsGate = command.SmsGate,
                Test = command.Test,
                Token = command.Token,
            };
        }
    }
}
