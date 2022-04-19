using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategoryEntity>
    {
        Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<SubCategoryEntity> GetSubCategoryById(Guid subCategoryId, CancellationToken cancellationToken = default);
    }
}
