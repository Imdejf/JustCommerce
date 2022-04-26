using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company
{
    public interface ILanguageRepository : IBaseRepository<LanguageEntity>
    {
        Task<bool> ExistNameOrIsoCode(string name, string isoCode);
    }
}
