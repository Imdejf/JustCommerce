using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Manufacturer;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Manufacturer
{
    public interface IManufacturerRepository : IBaseRepository<ManufacturerEntity>
    {
        Task<ManufacturerEntity?> GetFullyByIdAsync(Guid manufacturerId, CancellationToken cancellationToken);
    }
}
