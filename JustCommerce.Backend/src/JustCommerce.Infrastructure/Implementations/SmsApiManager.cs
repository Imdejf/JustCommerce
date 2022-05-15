using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class SmsApiManager : ISmsApiManager
    {
        private readonly FtpFileConfig _ftpFileConfig;
        public SmsApiManager(IOptions<FtpFileConfig> ftpFileConfig)
        {
            _ftpFileConfig ??= ftpFileConfig.Value;
        }

    }
}
