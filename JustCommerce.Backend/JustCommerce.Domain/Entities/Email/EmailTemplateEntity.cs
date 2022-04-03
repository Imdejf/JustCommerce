﻿using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.Email
{
    public sealed class EmailTemplateEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid EmailAccountId { get; set; }
        public EmailAccountEntity EmailAccount { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public string EmailName { get; set; }
        public string Subject { get; set; } 
        public bool Actvie { get; set; }
        public EmailType EmailType { get; set; }
    }
}
