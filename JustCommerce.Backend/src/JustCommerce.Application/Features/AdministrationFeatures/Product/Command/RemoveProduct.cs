using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Command
{
    public static class RemoveProduct
    {

        public sealed record Command(Guid ProductId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _unitOfWorkAdministration.Product.GetByIdAsync(request.ProductId, cancellationToken);

                if (product is null)
                {
                    throw new EntityNotFoundException($"Category with Id : {request.ProductId} doesn`t exists");
                }

                _unitOfWorkAdministration.Product.Remove(product);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.productId).NotEqual(Guid.Empty);
            }
        }

    }
}
