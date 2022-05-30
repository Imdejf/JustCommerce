using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.Notification.Command
{
    public static class CompleteNotification
    {
        public sealed record Command(Guid SendNotificationId, Guid UserId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkCommon _unitOfWorkCommon;

            public Handler(IUnitOfWorkCommon unitOfWorkCommon)
            {
                _unitOfWorkCommon = unitOfWorkCommon;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkCommon.UserNotification.ExistsAsync(request.SendNotificationId, cancellationToken))
                {
                    throw new EntityNotFoundException("UserNotification is not exists");
                }

                if (!await _unitOfWorkCommon.UserNotification.IsBindedWithUserAsync(request.SendNotificationId, request.UserId, cancellationToken))
                {
                    throw new InvalidRequestException("Send user id not binded with send SendNotification");
                }

                _unitOfWorkCommon.UserNotification.Complete(request.SendNotificationId);
                await _unitOfWorkCommon.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
                RuleFor(c => c.SendNotificationId).NotEqual(Guid.Empty);
            }
        }
    }
}
