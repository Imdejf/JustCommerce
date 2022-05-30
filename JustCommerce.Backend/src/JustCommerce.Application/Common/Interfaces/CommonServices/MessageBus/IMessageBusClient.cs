using JustCommerce.Application.Models.MessageBus.Abstract;

namespace JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus
{
    public interface IMessageBusClient
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : BaseNotificationEvent;
    }
}
