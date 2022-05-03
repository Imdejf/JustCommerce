using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product;
using JustCommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product
{
    internal sealed class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DbSet<ProductEntity> entity) : base(entity)
        {
        }

        public async Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(c => c.Slug == slug).AnyAsync(cancellationToken);
        }

        public async Task<ProductEntity?> GetProductFullObject(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _entity
                        .Include(c => c.ProductType)
                        .Include(c => c.ProductLang)
                        .Include(c => c.ProductFile)
                        .FirstOrDefaultAsync(c => c.Id == productId, cancellationToken);
        }
    }
}
