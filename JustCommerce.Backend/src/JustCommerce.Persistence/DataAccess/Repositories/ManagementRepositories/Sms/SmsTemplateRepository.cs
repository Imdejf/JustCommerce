using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Sms;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Sms;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Sms
{
    internal sealed class SmsTemplateRepository : BaseRepository<SmsTemplateEntity>, ISmsTemplateRepository
    {
        public SmsTemplateRepository(DbSet<SmsTemplateEntity> entity) : base(entity)
        {
        }

        public Task<List<SmsTemplateEntity>> GetAllByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.ShopId == shopId).ToListAsync(cancellationToken);
        }

        public Task<SmsTemplateEntity> GetFullyObject(Guid smsTemplateId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.SmsTemplateLang)
                          .Where(c => c.Id == smsTemplateId)
                          .FirstAsync(cancellationToken);
        }
    }
}
