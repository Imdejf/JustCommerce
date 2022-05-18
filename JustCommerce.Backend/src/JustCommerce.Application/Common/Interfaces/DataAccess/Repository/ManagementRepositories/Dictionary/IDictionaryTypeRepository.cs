using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Dictionary;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Dictionary
{
    public interface IDictionaryTypeRepository : IBaseRepository<DictionaryTypeEntity>
    {
        Task<List<DictionaryTypeEntity>> GetAllByShopId(Guid shopId, CancellationToken cancellationToken = default);
    }
}
