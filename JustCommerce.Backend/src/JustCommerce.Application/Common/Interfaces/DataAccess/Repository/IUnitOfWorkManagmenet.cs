using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Language;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Permission;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IBaseRepository<StoreEntity> Store { get; }
        IPermissionReposiotry Permission { get; }
        IBaseRepository<LanguageEntity> Language { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
