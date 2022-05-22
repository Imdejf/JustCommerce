using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Order;
using JustCommerce.Application.Common.Factories.EntitiesFactories.command;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Offer;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.Order.Command
{
    public static class CreateOrder
    {

        public sealed record Command(Guid ShopId,Guid MemberId, OrderStatus OrderStatus, string CustomerName, string CustomerEmail, string CustomerPhone, string InvoiceRecipeintName, string InvoiceRecipientTax,
                                     string InvoiceRecipientCountry, string InvoiceRecipientRegion, string InvoiceRecipientCity, string InvoiceRecipientPostalCode, string InvoiceRecipientAddress,
                                     bool DifferentShipmentRecipient, string ShipmentRecipientName, string ShipmentRecipientCountry, string ShipmentRecipientRegion, string ShipmentRecipientCity,
                                     string ShipmentRecipientPostalCode, string ShipmentRecipientAddress, decimal TotallPriceGross, decimal ShipmentPrice, decimal ItemsSumPriceGross, decimal PaymentsSum,
                                     Guid ShipmentMethodId, string AdditionalInfo, bool OrderPdf, bool Paid, bool Invoice, string Note, Guid LanguageVersionId, bool NewsletterAcceptation, bool StatueAcceptation,
                                     bool DataProcessingAcceptation, int PaymentType, bool FastInvoice, bool PaymentCallSent, bool IncludeShipmentRecipientOnInvoice,bool SmsNotification, string InvoiceEmail, int TradeCreditDays,
                                     bool PaymentReminderSend, OrderSource Source, int Rated) : IRequestWrapper<OrderDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, OrderDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<OrderDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var newOrder = OrderEntityFactory.CreateFromCommand(request);

                await _unitOfWorkAdministration.Order.AddAsync(newOrder, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);
                return null;
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
