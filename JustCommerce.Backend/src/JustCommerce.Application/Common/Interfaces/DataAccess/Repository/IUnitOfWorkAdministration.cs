using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductAttributeRepository ProductAttribute { get; }
        IBaseRepository<SpecificationAttributeGroupEntity> SpecificationAttributeGroup { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
