using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Category;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Category;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Category;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Category.Command
{
    public static class UpdateCategory
    {

        public sealed record Command() : IRequest<CategoryDTO>
        {
            public Guid CategoryId { get; set; }
            public Guid? ParentCategoryId { get; set; }
            public bool ShowOnHomepage { get; set; }
            public bool IncludeInTopMenu { get; set; }
            public bool SubjectToAcl { get; set; }
            public bool Published { get; set; }
            public bool Deleted { get; set; }
            public int DisplayOrder { get; set; }
            public bool PriceRangeFiltering { get; set; }
            public decimal PriceFrom { get; set; }
            public decimal PriceTo { get; set; }
            public bool ManuallyPriceRange { get; set; }
            public ICollection<CategoryLangDTO> CategoryLang { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, CategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<CategoryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentCategory = await _unitOfWorkAdministration.Category.GetFullyByIdAsync(request.CategoryId, cancellationToken);

                if (currentCategory is null)
                {
                    throw new EntityNotFoundException($"Category with id {request.CategoryId} doesnt exist");
                }

                currentCategory.IncludeInTopMenu = request.IncludeInTopMenu;
                currentCategory.ManuallyPriceRange = request.ManuallyPriceRange;
                currentCategory.SubjectToAcl = request.SubjectToAcl;
                currentCategory.UpdatedOnUtc = DateTime.Now;
                currentCategory.Published = request.Published;
                currentCategory.PriceRangeFiltering = request.PriceRangeFiltering;
                currentCategory.DisplayOrder = request.DisplayOrder;
                currentCategory.ShowOnHomepage = request.ShowOnHomepage;
                currentCategory.PriceTo = request.PriceTo;
                currentCategory.PriceFrom = request.PriceFrom;
                currentCategory.ParentCategoryId = request.ParentCategoryId;

                foreach(var lang in request.CategoryLang)
                {
                    var category = currentCategory.CategoryLang.Where(c => c.LanguageId == lang.LanguageId && c.CategoryId == lang.CategoryId).FirstOrDefault();

                    if(category is null)
                    {
                        var entity = CategoryLangEntityFactory.CreateFromDto(lang);
                        currentCategory.CategoryLang.Add(entity);
                    }
                    else
                    {
                        category.MetaDescription = lang.MetaDescription;
                        category.Description = lang.Description;
                        category.MetaTitle = lang.MetaTitle;
                        category.Name = lang.Name;
                        category.MetaKeywords = lang.MetaKeywords;
                    }
                }

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = CategoryDtoFactory.CreateFromEntity(currentCategory);

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.CategoryId).NotEqual(Guid.Empty);
            }
        }


    }
}
