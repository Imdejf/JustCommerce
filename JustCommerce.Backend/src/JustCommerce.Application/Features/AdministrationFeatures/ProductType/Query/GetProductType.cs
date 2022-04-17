using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query
{
    public static class GetProductType
    {
        public sealed record Query : IRequestWrapper<List<ProductTypeDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<ProductTypeDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<ProductTypeDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
               var productTypeList = await _unitOfWorkAdministration.ProductType.GetAllAsync(cancellationToken);
               return productTypeList.Select(c => ProductTypeDtoFactory.CreateFromEntity(c)).ToList();
            }
        }
    }
}
