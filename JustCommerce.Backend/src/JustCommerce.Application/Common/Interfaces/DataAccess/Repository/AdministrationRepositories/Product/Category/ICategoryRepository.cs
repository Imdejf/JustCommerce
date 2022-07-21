using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Category;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Category
{
    public interface ICategoryRepository : IBaseRepository<CategoryEntity>
    {
        Task<CategoryEntity?> GetFullyByIdAsync(Guid categoryId, CancellationToken cancellationToken);
    }
}
