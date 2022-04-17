using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories;
using JustCommerce.Domain.Entities.ProductType;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories
{
    internal sealed class ProductTypePropertyRepository : BaseRepository<ProductTypePropertyEntity>, IProductTypePropertyRepository
    {
        public ProductTypePropertyRepository(DbSet<ProductTypePropertyEntity> entity) : base(entity) { }

        public async Task AddRangeProductTypePropertyAsync(List<ProductTypePropertyEntity> productTypePropertyList, CancellationToken cancellationToken = default)
        {
            await _entity.AddRangeAsync(productTypePropertyList, cancellationToken);
        }
    }
}
