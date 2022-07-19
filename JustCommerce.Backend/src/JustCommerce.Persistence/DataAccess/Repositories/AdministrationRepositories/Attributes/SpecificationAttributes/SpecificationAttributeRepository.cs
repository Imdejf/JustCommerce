using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.SpecificationAttributes
{
    internal sealed class SpecificationAttributeRepository : BaseRepository<SpecificationAttributeEntity>, ISpecificationAttributeRepository
    {
        public SpecificationAttributeRepository(DbSet<SpecificationAttributeEntity> entity) : base(entity)
        {
        }

        public Task<SpecificationAttributeEntity?> GetFullyById(Guid specificationAttributeId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.SpecificationAttributeGroup)
                          .Include(c => c.SpecificationAttributeOption)
                          .ThenInclude(c => c.SpecificationAttributeOptionLang)
                          .Where(c => c.Id == specificationAttributeId)
                          .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
