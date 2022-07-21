using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Tags;
using JustCommerce.Domain.Entities.Products.Tags;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.Tags
{
    internal sealed class ProductTagRepository : BaseRepository<ProductTagEntity>, IProductTagRepository
    {
        public ProductTagRepository(DbSet<ProductTagEntity> entity) : base(entity)
        {
        }

        public Task<ProductTagEntity?> GetFullyAsync(Guid productTagId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Id == productTagId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<ProductTagEntity?> GetProductTagByNameAsync(string tagName,Guid languageId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Name == tagName && c.LanguageId == languageId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
