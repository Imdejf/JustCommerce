using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Attributes;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes
{
    public interface ISpecificationAttributeGroupRepository : IBaseRepository<SpecificationAttributeGroupEntity>
    {
        Task<List<SpecificationAttributeGroupEntity>> GetAllFullyAsync(Guid storeId, CancellationToken cancellationToken = default);
    }
}
