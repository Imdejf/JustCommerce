using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Category;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Command
{
    public static class CreateSubCategory
    {

        public sealed record Command(Guid CategoryId, string Slug, string IconPath, int OrderValue, List<SubCategoryLangsDTO> SubCategoryLangs) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var existSlug = await _unitOfWorkAdministration.SubCategory.ExistSlugAsync(request.Slug, cancellationToken);

                if(existSlug)
                {
                    throw new EntityNotFoundException($"Slug exists");
                }

                var newCategory = SubCategoryEntityFactory.CreateFromCategoryCommand(request);

                newCategory.SubCategoryLang = request.SubCategoryLangs
                                                      .Select(c => SubCategoryLangEntityFactory.CreateFromData(newCategory.Id, c.Name, c.Content, c.Description, c.IsoCode, c.Keywords))
                                                      .ToList();

                await _unitOfWorkAdministration.SubCategory.AddAsync(newCategory, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }

    }
}
