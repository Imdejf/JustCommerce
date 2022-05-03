using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product
{
    public interface IProductFileRepository : IBaseRepository<ProductFileEntity>
    {
        Task AddRangePhoto(List<ProductFileEntity> productFile, CancellationToken cancellationToken = default);
    }
}
