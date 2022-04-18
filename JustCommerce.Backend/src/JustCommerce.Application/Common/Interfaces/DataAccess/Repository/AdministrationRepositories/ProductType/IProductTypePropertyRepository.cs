using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ProductType
{
    public interface IProductTypePropertyRepository : IBaseRepository<ProductTypePropertyEntity>
    {
        Task AddRangeProductTypePropertyAsync(List<ProductTypePropertyEntity> productTypePropertyList, CancellationToken cancellationToken = default);
    }
}
