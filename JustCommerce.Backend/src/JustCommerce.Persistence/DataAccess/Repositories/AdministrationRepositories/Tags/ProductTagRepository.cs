using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Tags;
using JustCommerce.Domain.Entities.Products.Tags;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Tags
{
    internal sealed class ProductTagRepository : BaseRepository<ProductTagEntity>, IProductTagRepository
    {
        public ProductTagRepository(DbSet<ProductTagEntity> entity) : base(entity)
        {
        }

        public Task<ProductTagEntity?> GetFullyAsync(Guid productTagId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Id == productTagId).Include(c => c.ProductTagLang).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
