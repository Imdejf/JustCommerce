using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.ProductAttributes
{
    internal sealed class PredefinedProductAttributeValueRepository : BaseRepository<PredefinedProductAttributeValueEntity>, IPredefinedProductAttributeValueRepository
    {
        public PredefinedProductAttributeValueRepository(DbSet<PredefinedProductAttributeValueEntity> entity) : base(entity)
        {
        }
    }
}
