using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories
{
    public interface IProductTypeRepository : IBaseRepository<ProductTypeEntity>
    {
        Task<ProductTypeEntity?> GetWithProductTypePropertyByIdAsync(Guid productTypeId, CancellationToken cancellationToken = default);
    }
}
