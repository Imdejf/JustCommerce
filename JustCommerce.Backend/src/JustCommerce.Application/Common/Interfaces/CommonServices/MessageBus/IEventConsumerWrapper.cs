using JustCommerce.Application.Models.MessageBus.Abstract;

namespace JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus
{
    public interface IEventConsumerWrapper
    {
        Task ConsumeAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : BaseNotificationEvent;
    }
}
