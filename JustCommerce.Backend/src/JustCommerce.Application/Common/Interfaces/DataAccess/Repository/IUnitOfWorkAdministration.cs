using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ProductType;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductTypeRepository ProductType { get; }
        IProductTypePropertyRepository ProductTypeProperty { get; }
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }
        IProductRepository Product { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
