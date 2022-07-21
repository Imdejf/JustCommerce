using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.SpecificationAttributes
{
    internal sealed class SpecificationAttributeOptionRepository : BaseRepository<SpecificationAttributeOptionEntity>, ISpecificationAttributeOptionRepository
    {
        public SpecificationAttributeOptionRepository(DbSet<SpecificationAttributeOptionEntity> entity) : base(entity)
        {
        }
    }
}
