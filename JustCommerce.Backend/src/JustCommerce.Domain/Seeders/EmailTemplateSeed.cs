using JustCommerce.Domain.Common;
using JustCommerce.Domain.Entities.Email;

namespace JustCommerce.Domain.Seeders
{
    public static class EmailTemplateSeed
    {
        public static BaseSeed<EmailTemplateEntity> BaseSeed = new BaseSeed<EmailTemplateEntity>(SeedEmailTemplate);

        private static IEnumerable<EmailTemplateEntity> SeedEmailTemplate => new List<EmailTemplateEntity>()
        {
            new EmailTemplateEntity("cf702e9b-cceb-476f-ba6e-455004ebf588","6cef7328-534d-4699-98af-8779fba7d3a1", "014e3b4b-e2a7-4499-8c82-a905b7b086e2", "EmailConfirmed", Directory.GetCurrentDirectory().Split("bin")[0] + $@"\Templates\EmailTemplates\6cef7328-534d-4699-98af-8779fba7d3a1\EmailConfirmation.html","kontakt@emagazynowo.pl", "eMagazynowo", "eMagazynowo : Potwierdzenie rejestracji", true, Enums.EmailType.ConfirmAccount)
        };
    }
}
