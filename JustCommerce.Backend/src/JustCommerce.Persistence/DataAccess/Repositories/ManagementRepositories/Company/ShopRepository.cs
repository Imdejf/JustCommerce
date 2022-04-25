using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;
using JustCommerce.Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Company
{
    internal class ShopRepository : BaseRepository<ShopEntity>, IShopRepository
    {
        public ShopRepository(DbSet<ShopEntity> entity) : base(entity)
        {
        }
    }
}
