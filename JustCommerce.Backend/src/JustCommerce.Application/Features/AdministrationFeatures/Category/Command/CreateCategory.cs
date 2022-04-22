using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Command
{
    public static class CreateCategory
    {

        public sealed record Command(string Slug, string IconPath, int OrderValue,Guid? ParentId, List<CategoryLangsDTO> CategoryLangs) : IRequestWrapper<CategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, CategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<CategoryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var existSlug = await _unitOfWorkAdministration.Category.ExistSlugAsync(request.Slug);

                if (existSlug)
                {
                    throw new EntityNotFoundException($"Slug exists");
                }

                var newCategory = CategoryEntityFactory.CreateFromCategoryCommand(request);

                newCategory.CategoryLang = request.CategoryLangs
                                                      .Select(c => CategoryLangEntityFactory.CreateFromData(newCategory.Id, c.Name, c.Content, c.Description, c.IsoCode, c.Keywords))
                                                      .ToList();

                await _unitOfWorkAdministration.Category.AddAsync(newCategory, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return CategoryDtoFactory.CreateFromEntity(newCategory);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Slug).NotEmpty();
            }
        }

    }
}
 