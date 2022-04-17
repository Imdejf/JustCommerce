using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductTypeRepository ProductType { get; }
        IProductTypePropertyRepository ProductTypeProperty { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
