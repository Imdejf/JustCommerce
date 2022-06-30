using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;
using JustCommerce.Domain.Entities.Language;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Company
{
    internal sealed class LanguageReposiotry : BaseRepository<LanguageEntity>, ILanguageRepository
    {
        public LanguageReposiotry(DbSet<LanguageEntity> entity) : base(entity)
        {
        }

        public Task<List<LanguageEntity>> GetLanguageByShopId(Guid shopId, CancellationToken cancellationToken)
        {
            return _entity.Where(c => c.ShopId == shopId).ToListAsync(cancellationToken);
        }

        public Task<bool> ExistNameOrIsoCode(string name, string isoCode)
        {
            return _entity.AnyAsync(c => c.IsoCode == isoCode || c.NameOrginal == name);
        }
    }
}
