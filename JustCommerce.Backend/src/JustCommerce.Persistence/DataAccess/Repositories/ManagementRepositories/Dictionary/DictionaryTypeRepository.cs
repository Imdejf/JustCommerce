using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Dictionary;
using JustCommerce.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Dictionary
{
    internal sealed class DictionaryTypeRepository : BaseRepository<DictionaryTypeEntity>, IDictionaryTypeRepository
    {
        public DictionaryTypeRepository(DbSet<DictionaryTypeEntity> entity) : base(entity)
        {

        }
    }
}
