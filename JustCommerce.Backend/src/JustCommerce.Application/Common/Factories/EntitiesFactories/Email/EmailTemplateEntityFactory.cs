using JustCommerce.Application.Features.ManagemenetFeatures.EmailTemplate.Command;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Email
{
    public static class EmailTemplateEntityFactory
    {
        public static EmailTemplateEntity CreateFromEmailTemplateCommand(CreateEmailTemplate.Command command)
        {
            return new EmailTemplateEntity
            {
                ShopId = command.ShopId,
                EmailAccountId = command.EmailAccountId,
                Subject = command.Subject,
                Active = command.Active,
                Email = command.Email,
                Name = command.Name,
                EmailType = command.EmailType,
                EmailName = command.EmailName,
            };
        }
    }
}
