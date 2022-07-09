using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IBaseRepository<ProductAttributeEntity> ProductAttribute { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
