using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Store;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IBaseRepository<StoreEntity> Store { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
