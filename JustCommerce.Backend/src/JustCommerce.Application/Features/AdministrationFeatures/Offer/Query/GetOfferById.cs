using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Offer;
using JustCommerce.Application.Common.Factories.DtoFactories.Offer;
using JustCommerce.Application.Common.Interfaces;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Offer.Query
{
    public static class GetOfferById
    {

        public sealed record Query(Guid OfferId) : IRequestWrapper<OfferDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, OfferDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<OfferDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var offer = await _unitOfWorkAdministration.Offer.GetByIdAsync(request.OfferId, cancellationToken);
                return OfferDtoFactory.CreateFromEntity(offer);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.OfferId).NotEqual(Guid.Empty);
            }
        }

    }
}
