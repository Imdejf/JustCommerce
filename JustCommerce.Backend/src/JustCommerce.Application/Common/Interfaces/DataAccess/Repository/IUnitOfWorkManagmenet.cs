using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Sms;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        IShopRepository Shop { get; }
        ILanguageRepository Language { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        IEmailAccountRepository EmailAccount { get; }
        ISmsAccountReposiotry SmsAccount { get; }
        //ISmsTemplateRepository SmsTemplate { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
