using JustCommerce.Application.Common.DTOs.Email;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Email
{
    public static class EmailTemplateDtoFactory
    {
        public static EmailTemplateDTO CreateFromEntity(EmailTemplateEntity emailTemplate)
        {
            return new EmailTemplateDTO
            {
                Active = emailTemplate.Active,
                ShopId = emailTemplate.ShopId,
                Subject = emailTemplate.Subject,
                EmailAccountId = emailTemplate.EmailAccountId,
                EmailName = emailTemplate.EmailName,
                EmailType = emailTemplate.EmailType,
                FilePath = emailTemplate.FilePath,
                Name = emailTemplate.Name,
                Email = emailTemplate.Email
            };
        }
    }
}
