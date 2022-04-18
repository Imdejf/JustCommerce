using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ProductType;
using JustCommerce.Domain.Entities.ProductType;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.ProductType
{
    internal sealed class ProductTypeRepository : BaseRepository<ProductTypeEntity>, IProductTypeRepository
    {
        public ProductTypeRepository(DbSet<ProductTypeEntity> entity) : base(entity)
        {
        }

        public async Task<ProductTypeEntity?> GetWithProductTypePropertyByIdAsync(Guid productTypeId, CancellationToken cancellationToken)
        {
            return await _entity.Include(c => c.ProductTypeProperty).ThenInclude(c => c.ProductTypePropertyLang).Where(c => c.Id == productTypeId).Include(c => c.ProductTypeProperty).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
