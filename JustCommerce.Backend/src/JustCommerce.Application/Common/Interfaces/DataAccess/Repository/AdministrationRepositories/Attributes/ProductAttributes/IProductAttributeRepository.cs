using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes
{
    public interface IProductAttributeRepository : IBaseRepository<ProductAttributeEntity>
    {
        Task<ProductAttributeEntity?> GetFullyProductAttributeAsync(Guid productAttributeId, CancellationToken cancellationToken = default);
    }
}
