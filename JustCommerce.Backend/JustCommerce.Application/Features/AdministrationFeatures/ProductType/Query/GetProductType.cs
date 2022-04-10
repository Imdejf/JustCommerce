using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query
{
    public static class GetProductType
    {
        public sealed record Query : IRequestWrapper<List<ProductTypeEntity>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<ProductTypeEntity>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<ProductTypeEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _unitOfWorkAdministration.ProductType.GetAllAsync(cancellationToken);
            }
        }
    }
}
