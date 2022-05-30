using JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus;
using JustCommerce.Application.Common.Interfaces.Notification;
using JustCommerce.Application.Models.MessageBus.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Infrastructure.Implementations.Common.MessageBus
{
    public sealed class EventConsumerWrapper : IEventConsumerWrapper
    {
        private readonly IServiceProvider _serviceProvider;
        public EventConsumerWrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task ConsumeAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : BaseNotificationEvent
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var instanceNotificationHubClient = serviceScope.ServiceProvider.GetRequiredService<INotificationHubClientWrapper>();
                await instanceNotificationHubClient.SendNotification(@event, cancellationToken);

                var consumerInstance = serviceScope.ServiceProvider.GetRequiredService<IEventConsumer<TEvent>>();
                if (consumerInstance != null)
                {
                    await consumerInstance.ConsumeAsync(@event, cancellationToken);
                }
            }
        }
    }
}
