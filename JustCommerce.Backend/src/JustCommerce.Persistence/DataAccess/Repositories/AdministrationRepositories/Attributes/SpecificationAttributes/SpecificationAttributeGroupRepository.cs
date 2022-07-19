using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.SpecificationAttributes
{
    internal sealed class SpecificationAttributeGroupRepository : BaseRepository<SpecificationAttributeGroupEntity>, ISpecificationAttributeGroupRepository
    {
        public SpecificationAttributeGroupRepository(DbSet<SpecificationAttributeGroupEntity> entity) : base(entity)
        {
        }

        public Task<List<SpecificationAttributeGroupEntity>> GetAllFullyAsync(Guid storeId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.SpecificationAttribute).Where(c => c.StoreId == storeId).ToListAsync(cancellationToken);
        }
    }
}
