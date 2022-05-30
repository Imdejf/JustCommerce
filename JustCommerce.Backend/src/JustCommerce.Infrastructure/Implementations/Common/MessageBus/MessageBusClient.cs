using JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus;
using JustCommerce.Application.Models.MessageBus.Abstract;
using RawRabbit;

namespace JustCommerce.Infrastructure.Implementations.Common.MessageBus
{
    public sealed class MessageBusClient : IMessageBusClient
    {
        private readonly IBusClient _busClient;
        public MessageBusClient(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : BaseNotificationEvent
        {
            return _busClient.PublishAsync(@event, token: cancellationToken);
        }
    }
}
