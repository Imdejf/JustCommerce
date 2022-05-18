using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Dictionary
{
    public interface IDictionaryRepository : IBaseRepository<DictionaryEntity>
    {
        Task<DictionaryEntity> GetFullyObject(Guid dictionaryId, CancellationToken cancellationToken = default);
    }
}
