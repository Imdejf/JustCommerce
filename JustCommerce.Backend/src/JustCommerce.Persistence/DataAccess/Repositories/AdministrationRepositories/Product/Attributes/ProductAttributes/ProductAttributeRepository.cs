using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.ProductAttributes
{
    internal class ProductAttributeRepository : BaseRepository<ProductAttributeEntity>, IProductAttributeRepository
    {
        public ProductAttributeRepository(DbSet<ProductAttributeEntity> entity) : base(entity)
        {
        }

        public Task<ProductAttributeEntity?> GetFullyProductAttributeAsync(Guid productAttributeId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.ProductAttributeLang)
                          .Include(c => c.PredefinedProductAttributeValue)
                          .ThenInclude(c => c.PredefinedProductAttributeValueLang)
                          .Where(c => c.Id == productAttributeId)
                          .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
