using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Product;
using JustCommerce.Domain.Entities.Products.Product;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Product
{
    internal sealed class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DbSet<ProductEntity> entity) : base(entity)
        {
        }
    }
}
