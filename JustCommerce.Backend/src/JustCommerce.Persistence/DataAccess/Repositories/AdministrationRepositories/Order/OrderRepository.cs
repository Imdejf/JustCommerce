using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Order;
using JustCommerce.Domain.Entities.Order;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Order
{
    internal sealed class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(DbSet<OrderEntity> entity) : base(entity) { }

        public Task<OrderEntity> GetFullyObject(Guid orderId, CancellationToken cancellationToken)
        {
            return _entity.Include(c => c.LanguageVersion)
                          .FirstAsync(c => c.Id == orderId, cancellationToken);
        }
    }
}
