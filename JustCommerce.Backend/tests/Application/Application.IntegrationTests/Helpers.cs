using JustCommerce.Application.Common.DataAccess.Repository;
using MediatR;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public class Helpers
    {
        private readonly IMediator _mediator;
        public readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
        private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;

        private static object LockObj = new object();
        public Helpers(DependencyContainer container)
        {
            lock (LockObj)
            {
                _mediator = container.GetService<IMediator>();
                _unitOfWorkAdministration = container.GetService<IUnitOfWorkAdministration>();
                _unitOfWorkManagmenet = container.GetService<IUnitOfWorkManagmenet>();
            }
        }

        public async Task Send(IRequest message)
        {
            await _mediator.Send(message);
        }
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> message)
        {
            return _mediator.Send(message);
        }
    }
}
