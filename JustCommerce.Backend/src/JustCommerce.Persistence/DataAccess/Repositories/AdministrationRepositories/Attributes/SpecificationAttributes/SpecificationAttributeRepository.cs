using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.SpecificationAttributes
{
    internal sealed class SpecificationAttributeRepository : BaseRepository<SpecificationAttributeEntity>, ISpecificationAttributeRepository
    {
        public SpecificationAttributeRepository(DbSet<SpecificationAttributeEntity> entity) : base(entity)
        {
        }
    }
}
