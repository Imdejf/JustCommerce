using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface ISmsApiManager
    {
        Task SendSmsForSetStatus(string to, Guid shopId, Guid languageId, SmsType smsType,int orderNumber, CancellationToken cancellationToken = default);
    }
}
