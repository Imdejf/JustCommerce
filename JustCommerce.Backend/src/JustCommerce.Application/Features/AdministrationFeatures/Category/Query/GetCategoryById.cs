using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Query
{
    public static class GetCategoryById
    {

        public sealed record Query(Guid CategoryId) : IRequestWrapper<CategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, CategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<CategoryDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var category = await _unitOfWorkAdministration.CategoryRepository.GetCategoryById(request.CategoryId, cancellationToken);

                if (category is null)
                {
                    throw new EntityNotFoundException($"Category Id:{request.CategoryId}");
                }

                var categoryDto = CategoryDtoFactory.CreateFromEntity(category);

                return categoryDto;
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.CategoryId).NotEmpty();
            }
        }

    }
}
