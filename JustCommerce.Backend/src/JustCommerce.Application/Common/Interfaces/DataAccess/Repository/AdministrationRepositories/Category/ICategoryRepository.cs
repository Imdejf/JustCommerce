using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category
{
    public interface ICategoryRepository : IBaseRepository<CategoryEntity>
    {
        Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<CategoryEntity?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken = default);
    }
}
