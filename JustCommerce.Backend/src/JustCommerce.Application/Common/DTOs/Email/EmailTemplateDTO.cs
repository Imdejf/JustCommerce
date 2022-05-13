using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.DTOs.Email
{
    public class EmailTemplateDTO
    {
        public Guid ShopId { get; set; }
        public Guid EmailAccountId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public string EmailName { get; set; }
        public string Subject { get; set; }
        public bool Active { get; set; }
        public EmailType EmailType { get; set; }
    }
}
