using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Email;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Email
{
    internal class EmailTemplateRepository : BaseRepository<EmailTemplateEntity>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(DbSet<EmailTemplateEntity> entity) : base(entity)
        {
        }

        public Task<bool> ExistEmailTypeAsync(Guid shopId, EmailType emaiLType, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.EmailType == emaiLType && c.ShopId == shopId).AnyAsync(cancellationToken);
        }
    }
}
