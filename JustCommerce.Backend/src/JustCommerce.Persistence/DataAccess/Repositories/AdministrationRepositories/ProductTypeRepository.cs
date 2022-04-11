using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories;
using JustCommerce.Domain.Entities.ProductType;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories
{
    internal sealed class ProductTypeRepository : BaseRepository<ProductTypeEntity>, IProductTypeRepository
    {
        public ProductTypeRepository(DbSet<ProductTypeEntity> entity) : base(entity)
        {
        }
    }
}
