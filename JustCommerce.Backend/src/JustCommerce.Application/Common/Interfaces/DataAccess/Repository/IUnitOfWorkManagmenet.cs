using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IShopRepository Shop { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
