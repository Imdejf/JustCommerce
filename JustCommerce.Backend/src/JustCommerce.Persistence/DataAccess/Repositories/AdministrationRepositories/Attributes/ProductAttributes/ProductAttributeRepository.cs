using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.ProductAttributes
{
    internal class ProductAttributeRepository : BaseRepository<ProductAttributeEntity>, IProductAttributeRepository
    {
        public ProductAttributeRepository(DbSet<ProductAttributeEntity> entity) : base(entity)
        {
        }
    }
}
