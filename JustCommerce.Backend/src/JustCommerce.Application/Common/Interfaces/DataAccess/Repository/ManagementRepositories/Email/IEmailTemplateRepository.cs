using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email
{
    public interface IEmailTemplateRepository : IBaseRepository<EmailTemplateEntity>
    {
        Task<bool> ExistEmailTypeAsync(Guid shopId, EmailType emaiLType, CancellationToken cancellationToken = default);
    }
}
