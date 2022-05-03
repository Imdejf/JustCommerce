using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product;
using JustCommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product
{
    internal sealed class ProductFileReposiotry : BaseRepository<ProductFileEntity>, IProductFileRepository
    {
        public ProductFileReposiotry(DbSet<ProductFileEntity> entity) : base(entity)
        {
        }

        public async Task AddRangePhoto(List<ProductFileEntity> productFile, CancellationToken cancellationToken)
        {
            await _entity.AddRangeAsync(productFile, cancellationToken);
        }
    }
}
