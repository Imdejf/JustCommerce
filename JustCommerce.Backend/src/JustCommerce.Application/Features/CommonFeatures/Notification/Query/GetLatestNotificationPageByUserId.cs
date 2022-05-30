using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Notification;

namespace JustCommerce.Application.Features.CommonFeatures.Notification.Query
{
    public static class GetLatestNotificationPageByUserId
    {
        public sealed record Query(Guid UserId, int PageSize = 30, int PageNumber = 1) : IRequestWrapper<List<UserNotificationEntity>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, List<UserNotificationEntity>>
        {
            private readonly IUnitOfWorkCommon _unitOfWorkCommon;
            public Handler(IUnitOfWorkCommon unitOfWorkCommon)
            {
                _unitOfWorkCommon = unitOfWorkCommon;
            }

            public Task<List<UserNotificationEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _unitOfWorkCommon.UserNotification.GetLatestNotificationAsync(request.UserId, request.PageNumber, request.PageSize, cancellationToken);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            }
        }
    }
}
