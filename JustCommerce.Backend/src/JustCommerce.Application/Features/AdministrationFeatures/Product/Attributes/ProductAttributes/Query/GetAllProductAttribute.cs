using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Query
{
    public static class GetAllProductAttribute
    {

        public sealed record Query(Guid ShopId) : IRequest<List<ProductAttributeDTO>>;

        public sealed class Handler : IRequestHandler<Query, List<ProductAttributeDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<ProductAttributeDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productAttributeList = await _unitOfWorkAdministration.ProductAttribute.GetAllAsync(cancellationToken);

                throw new Exception();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }


    }
}
