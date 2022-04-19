using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<ProductEntity> GetCategoryById(Guid categoryId, CancellationToken cancellationToken = default);
    }
}
