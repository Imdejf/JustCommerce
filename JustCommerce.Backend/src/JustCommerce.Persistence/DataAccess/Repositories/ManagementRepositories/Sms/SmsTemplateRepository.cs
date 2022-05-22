using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Sms;
using JustCommerce.Domain.Entities.Sms;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Sms
{
    internal sealed class SmsTemplateRepository : BaseRepository<SmsTemplateEntity>, ISmsTemplateRepository
    {
        public SmsTemplateRepository(DbSet<SmsTemplateEntity> entity) : base(entity)
        {
        }
    }
}
