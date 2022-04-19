using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Category;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Command
{
    public static class UpdateSubCategory
    {

        public sealed record Command(Guid SubCategoryId, string Slug, string IconPath, int OrderValue, List<SubCategoryLangsDTO> CategoryLangs) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var subCategory = await _unitOfWorkAdministration.SubCategory.GetByIdAsync(request.SubCategoryId, cancellationToken);

                if(subCategory is null)
                {
                    throw new EntityNotFoundException($"SubCategory with Id : {request.SubCategoryId} doesn`t exists");
                }

                subCategory.Slug = request.Slug;
                subCategory.OrderValue = request.OrderValue;
                subCategory.IconPath = request.IconPath;

                foreach (var lang in subCategory.SubCategoryLang)
                {
                    var newLang = request.CategoryLangs.Where(c => c.IsoCode == lang.IsoCode).FirstOrDefault();
                    if (newLang != null)
                    {
                        lang.Name = newLang.Name;
                        lang.IsoCode = newLang.IsoCode;
                        lang.Description = newLang.Description;
                        lang.Content = newLang.Content;
                        lang.Keywords = newLang.Keywords;

                        request.CategoryLangs.Remove(newLang);
                    }

                }

                if (request.CategoryLangs.Any())
                {
                    for (int i = 0; i < request.CategoryLangs.Count; i++)
                    {
                        var lang = SubCategoryLangEntityFactory.CreateFromDto(request.CategoryLangs[i]);
                        subCategory.SubCategoryLang.Add(lang);
                    }
                }

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
