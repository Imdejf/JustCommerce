using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Permission;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IBaseRepository<StoreEntity> Store { get; }
        IPermissionReposiotry Permission { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
