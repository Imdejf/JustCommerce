using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Category;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Category;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Category;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Category.Command
{
    public static class CreateCategory
    {

        public sealed record Command() : IRequest<CategoryDTO>
        {
            public Guid StoreId { get; set; }
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
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<CategoryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }
                if (request.ParentCategoryId.HasValue)
                { 
                    if (!await _unitOfWorkAdministration.Category.ExistsAsync(request.ParentCategoryId.Value, cancellationToken))
                    {
                        throw new EntityNotFoundException($"Parent category with id: {request.ParentCategoryId} doesnt exist");
                    }
                }

                var newCategory = CategoryEntityFactory.CreateFromCommand(request);

                await _unitOfWorkAdministration.Category.AddAsync(newCategory, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = CategoryDtoFactory.CreateFromEntity(newCategory);

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
            }
        }


    }
}
