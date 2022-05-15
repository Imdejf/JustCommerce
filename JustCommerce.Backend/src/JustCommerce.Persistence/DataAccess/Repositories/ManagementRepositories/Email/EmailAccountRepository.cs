using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email;
using JustCommerce.Domain.Entities.Email;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Email
{
    internal class EmailAccountRepository : BaseRepository<EmailAccountEntity>, IEmailAccountRepository
    {
        public EmailAccountRepository(DbSet<EmailAccountEntity> entity) : base(entity)
        {
        }

        public Task<List<EmailAccountEntity>> GetAllByShopId(Guid shopId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.ShopId == shopId).ToListAsync(cancellationToken);
        }
    }
}
