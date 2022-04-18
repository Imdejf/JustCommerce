﻿using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class SubCategoryEntity : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public ICollection<SubCategoryLangEntity> SubCategoryLang { get; set; }
    }
}