namespace JustCommerce.Application.Common.DTOs.Product.Category
{
    public sealed class CategoryDTO
    {
        public Guid? ParentCategoryId { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool SubjectToAcl { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public bool PriceRangeFiltering { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool ManuallyPriceRange { get; set; }
        public Guid StoreId { get; set; }
        public ICollection<CategoryDTO> ChildCategory { get; set; }
        public ICollection<CategoryLangDTO> CategoryLang { get; set; }
    }
}
