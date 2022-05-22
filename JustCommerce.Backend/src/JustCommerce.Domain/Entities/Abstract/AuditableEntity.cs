﻿namespace JustCommerce.Domain.Entities.Abstract
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
