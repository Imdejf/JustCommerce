using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command
{
    public static class CreateProductType
    {

        public sealed record Command(string Name) : IRequestWrapper<ProductTypeEntity>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ProductTypeEntity>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductTypeEntity> Handle(Command request, CancellationToken cancellationToken)
            {
                var productType = new ProductTypeEntity
                {
                    Name = request.Name,
                };
                
                await _unitOfWorkAdministration.ProductType.AddAsync(productType, cancellationToken);
                
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);
                return productType;
            }
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty();
            }
        }
    }
}
