using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.SmsTemplate.Command
{
    public static class RemoveSmsTemplate
    {

        public sealed record Command(Guid SmsTemplateId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagemenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagemenet)
            {
                _unitOfWorkManagemenet = unitOfWorkManagemenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var smsTemplateExist = await _unitOfWorkManagemenet.SmsTemplate.ExistsAsync(request.SmsTemplateId, cancellationToken);

                if (!smsTemplateExist)
                {
                    throw new EntityNotFoundException($"SmsTemplate with Id : {request.SmsTemplateId} doesn`t exists");
                }

                _unitOfWorkManagemenet.SmsTemplate.RemoveById(request.SmsTemplateId);
                await _unitOfWorkManagemenet.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.SmsTemplateId).NotEqual(Guid.Empty);
            }
        }

    }
}
