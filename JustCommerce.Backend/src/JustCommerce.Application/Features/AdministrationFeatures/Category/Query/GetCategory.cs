using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
using MediatR;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Query
{
    public static class GetCategory
    {

        public sealed record Query() : IRequestWrapper<List<CategoryDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<CategoryDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public override async Task<List<CategoryDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categoryList = await _unitOfWorkAdministration.CategoryRepository.GetAllAsync(cancellationToken);
                return categoryList.Select(c => CategoryDtoFactory.CreateFromEntity(c)).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }

    }
}
