using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Command
{
    public static class UpdateCategory
    {

        public sealed record Command(Guid CategoryId, string Slug, string IconPath, int OrderValue, List<CategoryLangsDTO> CategoryLangs) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var categoryExist = await _unitOfWorkAdministration.Category.GetCategoryById(request.CategoryId, cancellationToken);

                if (categoryExist is null)
                {
                    throw new EntityNotFoundException($"Category with Id : {request.CategoryId} doesn`t exists");
                }

                categoryExist.Slug = request.Slug;
                categoryExist.OrderValue = request.OrderValue;
                categoryExist.IconPath = request.IconPath;

                foreach (var lang in categoryExist.CategoryLang)
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
                        var lang = CategoryLangEntityFactory.CreateFromDto(request.CategoryLangs[i]);
                        categoryExist.CategoryLang.Add(lang);
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
