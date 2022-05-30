using JustCommerce.Application.Models.MessageBus.Abstract;

namespace JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus
{
    public interface IEventConsumer<TEvent>
        where TEvent : BaseNotificationEvent
    {
        Task ConsumeAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
