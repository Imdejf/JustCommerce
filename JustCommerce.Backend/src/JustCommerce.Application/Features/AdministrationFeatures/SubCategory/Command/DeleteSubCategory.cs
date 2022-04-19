using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Command
{
    public static class DeleteSubCategory
    {

        public sealed record Command(Guid SubCategoryId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var subCategory = await _unitOfWorkAdministration.SubCategory.GetByIdAsync(request.SubCategoryId,cancellationToken);

                if (subCategory is null)
                {
                    throw new EntityNotFoundException($"SubCategory with Id : {request.SubCategoryId} doesn`t exists");
                }

                _unitOfWorkAdministration.SubCategory.Remove(subCategory);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.SubCategoryId).NotEmpty();
            }
        }

    }
}
