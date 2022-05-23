using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Sms
{
    public interface ISmsTemplateRepository : IBaseRepository<SmsTemplateEntity>
    {
        Task<SmsTemplateEntity> GetFullyObject(Guid smsTemplateId, CancellationToken cancellationToken = default);
        Task<List<SmsTemplateEntity>> GetAllByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default);
    }
}
