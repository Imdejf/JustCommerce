using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Sms;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Sms
{
    public interface ISmsAccountReposiotry : IBaseRepository<SmsAccountEntity>
    {
        public Task<List<SmsAccountEntity>> GetAllByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default);
    }
}
