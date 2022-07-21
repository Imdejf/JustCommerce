using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Manufacturer;
using JustCommerce.Domain.Entities.Products.Manufacturer;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.Manufacturer
{
    internal sealed class ManufacturerRepository : BaseRepository<ManufacturerEntity>, IManufacturerRepository
    {
        public ManufacturerRepository(DbSet<ManufacturerEntity> entity) : base(entity)
        {
        }

        public Task<ManufacturerEntity?> GetFullyByIdAsync(Guid manufacturerId, CancellationToken cancellationToken)
        {
            return _entity.Where(c => c.Id == manufacturerId)
                          .Include(c => c.ManufacturerLang)
                          .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
