using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email
{
    public interface IEmailAccountRepository : IBaseRepository<EmailAccountEntity>
    {
        Task<List<EmailAccountEntity>> GetAllByShopId(Guid shopId, CancellationToken cancellationToken = default);
    }
}
