using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using SMSApi.Api;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class SmsApiManager : ISmsApiManager
    {
        private readonly SmsApiConfig _ftpFileConfig;
        
        public SmsApiManager(IOptions<SmsApiConfig> ftpFileConfig)
        {
            _ftpFileConfig ??= ftpFileConfig.Value;
        }

        public void SendSms(string text, string to, string sender)
        {
            IClient client = new ClientOAuth(_ftpFileConfig.Token);
            var smsApi = new SMSFactory(client);

            var result = smsApi.ActionSend()
                               .SetText(text)
                               .SetTo(to)
                               .SetSender(sender)
                               .Execute;
        }
    }
}
