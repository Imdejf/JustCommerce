﻿using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Command
{
    public static class CreateCategory
    {

        public sealed record Command(string Slug, string IconPath, int OrderValue, List<CategoryLangsDTO> CategoryLangs) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var existSlug = await _unitOfWorkAdministration.CategoryRepository.ExistSlugAsync(request.Slug);

                if (existSlug)
                {
                    throw new EntityNotFoundException($"Slug exists");
                }

                var newCategory = CategoryEntityFactory.CreateFromCategoryCommand(request);

                newCategory.CategoryLang = request.CategoryLangs
                                                      .Select(c => CategoryLangEntityFactory.CreateFromData(newCategory.Id, c.Name, c.Content, c.Description, c.IsoCode, c.Keywords))
                                                      .ToList();

                await _unitOfWorkAdministration.CategoryRepository.AddAsync(newCategory, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
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
 