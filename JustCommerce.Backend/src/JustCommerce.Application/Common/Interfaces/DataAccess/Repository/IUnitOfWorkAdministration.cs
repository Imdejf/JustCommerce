using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Article;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ArticleCategory;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Offer;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Order;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ProductType;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductTypeRepository ProductType { get; }
        IProductTypePropertyRepository ProductTypeProperty { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProductFileRepository ProductFile { get; }
        IOfferRepository Offer { get; }
        IArticleRepository Article { get; }
        IArticleCategoryRepository ArticleCategory { get; }
        IOrderRepository Order { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
