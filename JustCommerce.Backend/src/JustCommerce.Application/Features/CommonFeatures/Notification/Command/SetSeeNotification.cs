using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Application.Common.Interfaces.DataAccess.Service;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.CommonFeatures.Notification.Command
{
    public static class SetSeeNotification
    {
        public sealed record Command(Guid SendNotificationId, Guid UserId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkCommon _unitOfWorkCommon;
            private readonly IUserManager _userManager;
            public Handler(IUnitOfWorkCommon unitOfWork, IUserManager userManager)
            {
                _unitOfWorkCommon = unitOfWork;
                _userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                if (!await _userManager.ExistsAsync(request.UserId, cancellationToken))
                {
                    throw new EntityNotFoundException("Send user id not found");
                }

                if (!await _unitOfWorkCommon.UserNotification.ExistsAsync(request.SendNotificationId, cancellationToken))
                {
                    throw new EntityNotFoundException("Send notification no exists");
                }

                if (!await _unitOfWorkCommon.UserNotification.IsBindedWithUserAsync(request.SendNotificationId, request.UserId, cancellationToken))
                {
                    throw new InvalidRequestException($"Notification with Id : {request.SendNotificationId} is not binded with User with Id : {request.UserId}");
                }

                _unitOfWorkCommon.UserNotification.See(request.SendNotificationId);
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
