using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category;
using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Category
{
    internal sealed class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DbSet<CategoryEntity> entity) : base(entity)
        {
        }

        public async Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken)
        {
            return await _entity.Where(c => c.Slug == slug).AnyAsync(cancellationToken);
        }

        public async Task<CategoryEntity> GetCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            return await _entity.Include(c => c.CategoryLang).FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
        }
    }
}
