using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category;
using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Category
{
    internal class SubCategoryRepository : BaseRepository<SubCategoryEntity>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbSet<SubCategoryEntity> entity) : base(entity)
        {
        }

        public async Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken)
        {
            return await _entity.Where(c => c.Slug == slug).AnyAsync(cancellationToken);
        }

        public async Task<SubCategoryEntity> GetSubCategoryById(Guid subCategoryId, CancellationToken cancellationToken)
        {
            return await _entity.Include(c => c.SubCategoryLang).FirstOrDefaultAsync(c => c.Id == subCategoryId, cancellationToken);
        }

    }
}
