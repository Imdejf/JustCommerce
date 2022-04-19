using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace JustCommerce.Application.Features.AdministrationFeatures.Category.Command
{
    public static class RemoveCategory
    {

        public sealed record Command(Guid CategoryId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var categoryExist = await _unitOfWorkAdministration.Category.GetByIdAsync(request.CategoryId, cancellationToken);

                if (categoryExist is null)
                {
                    throw new EntityNotFoundException($"Category with Id : {request.CategoryId} doesn`t exists");
                }

                _unitOfWorkAdministration.Category.Remove(categoryExist);
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
