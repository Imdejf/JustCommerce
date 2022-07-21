using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.SpecificationAttributes
{
    public interface ISpecificationAttributeRepository : IBaseRepository<SpecificationAttributeEntity>
    {
        Task<SpecificationAttributeEntity?> GetFullyById(Guid specificationAttributeId, CancellationToken cancellationToken = default);
    }
}
