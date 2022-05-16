using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Dictionary;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IShopRepository Shop { get; }
        ILanguageRepository Language { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        IEmailAccountRepository EmailAccount { get; }
        IDictionaryRepository Dictionary { get; }
        IDictionaryTypeRepository DictionaryType { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
