using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Factories.DtoFactories.Offer;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Offer.Command
{
    public static class SendOffer
    {

        public sealed record Command(Guid OfferId, Guid ShopId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IPdfBuilder _pdfBuilder;
            private readonly IMailSender _mailSender;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IPdfBuilder pdfBuilder, IMailSender mailSender)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _pdfBuilder = pdfBuilder;
                _mailSender = mailSender;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var offer = await _unitOfWorkAdministration.Offer.GetFullyOffer(request.OfferId, cancellationToken);

                if (offer is null)
                {
                    throw new EntityNotFoundException($"Offer with Id : {request.OfferId} doesn`t exists");
                }

                var pdfFile = await _pdfBuilder.OfferGenerate(offer);

                await _mailSender.SendEmailOfferAsync(offer.CustomerEmail, request.ShopId, Domain.Enums.EmailType.Offer, offer.OfferNumber.ToString(), pdfFile, cancellationToken);


                var offerDto = OfferDtoFactory.CreateFromEntity(offer);

                throw new Exception();
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.OfferId).NotEqual(Guid.Empty);
            }
        }

    }
}
