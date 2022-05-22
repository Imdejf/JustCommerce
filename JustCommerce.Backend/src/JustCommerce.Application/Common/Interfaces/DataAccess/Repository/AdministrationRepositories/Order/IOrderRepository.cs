using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Order;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Order
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        void SetOrderStatus(Guid orderId, OrderStatus orderStatus);
        Task<OrderEntity> GetFullyObject(Guid orderId, CancellationToken cancellationToken = default);
    }
}
