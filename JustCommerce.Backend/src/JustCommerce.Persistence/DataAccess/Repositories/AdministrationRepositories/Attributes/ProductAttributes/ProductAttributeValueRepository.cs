using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.ProductAttributes
{
    internal class ProductAttributeValueRepository : BaseRepository<ProductAttributeValueEntity>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(DbSet<ProductAttributeValueEntity> entity) : base(entity)
        {
        }
    }
}
