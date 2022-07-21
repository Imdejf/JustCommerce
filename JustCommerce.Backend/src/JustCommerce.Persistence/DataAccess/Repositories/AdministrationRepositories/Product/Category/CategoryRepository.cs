using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Category;
using JustCommerce.Domain.Entities.Products.Category;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Category
{
    internal sealed class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DbSet<CategoryEntity> entity) : base(entity)
        {
        }

        public Task<CategoryEntity?> GetFullyByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return _entity.Where(c => c.Id == categoryId).Include(c => c.CategoryLang).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
