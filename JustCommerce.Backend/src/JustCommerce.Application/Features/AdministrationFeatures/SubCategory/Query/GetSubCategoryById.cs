using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.Factories.DtoFactories.Category;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Query
{
    public static class GetSubCategoryById
    {

        public sealed record Query(Guid SubCategoryId) : IRequestWrapper<SubCategoryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, SubCategoryDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler()
            {
            }

            public async Task<SubCategoryDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var subCategory = await _unitOfWorkAdministration.SubCategory.GetSubCategoryById(request.SubCategoryId, cancellationToken);

                if (subCategory is null)
                {
                    throw new EntityNotFoundException($"Category Id:{request.SubCategoryId}");
                }

                var subCategoryDto = SubCategoryDtoFactory.CreateFromEntity(subCategory);

                return subCategoryDto;
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.SubCategoryId).NotEmpty();
            }
        }

    }
}
