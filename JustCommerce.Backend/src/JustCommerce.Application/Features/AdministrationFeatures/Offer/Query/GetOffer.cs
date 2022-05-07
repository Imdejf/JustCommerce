using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Offer;
using JustCommerce.Application.Common.Factories.DtoFactories.Offer;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.AdministrationFeatures.Offer.Query
{
    public static class GetOffer
    {

        public sealed record Query() : IRequestWrapper<List<OfferDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<OfferDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<List<OfferDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var offerList = await _unitOfWorkAdministration.Offer.GetAllAsync(cancellationToken);
                return offerList.Select(c => OfferDtoFactory.CreateFromEntity(c)).ToList();
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
