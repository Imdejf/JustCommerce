using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Tags;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Tags
{
    public interface IProductTagRepository : IBaseRepository<ProductTagEntity>
    {
        Task<ProductTagEntity?> GetFullyAsync(Guid productTagId, CancellationToken cancellationToken = default);
        Task<ProductTagEntity?> GetProductTagByNameAsync(string tagName, Guid languageId, CancellationToken cancellationToken = default);
    }
}
