using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Manufacturer;
using JustCommerce.Domain.Entities.Products.Manufacturer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Manufacturer
{
    internal sealed class ManufacturerRepository : BaseRepository<ManufacturerEntity>, IManufacturerRepository
    {
        public ManufacturerRepository(DbSet<ManufacturerEntity> entity) : base(entity)
        {
        }

        public Task<ManufacturerEntity?> GetFullyAsync(Guid manufacturerId, CancellationToken cancellationToken)
        {
            return _entity.Where(c => c.Id == manufacturerId)
                          .Include(c => c.ManufacturerLang)
                          .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
