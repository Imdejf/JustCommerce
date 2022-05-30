using JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus;
using JustCommerce.Application.Models.MessageBus.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;
using System.Reflection;

namespace JustCommerce.Infrastructure.Implementations.Common.MessageBus
{
    public sealed class MessageBusClientBuilder : IMessageBusConnectionBuilder<IBusClient>,
          IMessageBusConnectionSetAssemblyBuilder<IBusClient>,
          IMessageBusConnectionSubscribeToEventBuilder<IBusClient>
    {
        private Assembly _consumerAssembly;
        private IBusClient _busClient;
        private IServiceCollection _services;
        public MessageBusClientBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public IMessageBusConnectionSetAssemblyBuilder<IBusClient> ApplyConfiguration(IConfigurationSection section)
        {
            var config = new RawRabbitConfiguration();
            section.Bind(config);
            _busClient = RawRabbitFactory.CreateSingleton(new RawRabbitOptions() { ClientConfiguration = config });
            return this;
        }

        public IMessageBusConnectionSubscribeToEventBuilder<IBusClient> RegisterConsumers(Assembly assembly)
        {
            _consumerAssembly = assembly;
            return this;
        }

        public IMessageBusConnectionSubscribeToEventBuilder<IBusClient> SubscribeToEvent<TEvent>() where TEvent : BaseNotificationEvent
        {
            var type = _consumerAssembly.GetTypes()
                .Where(c => c.IsAssignableTo(typeof(IEventConsumer<TEvent>)))
                .FirstOrDefault();

            if (type != null)
            {
                _services.AddTransient(typeof(IEventConsumer<TEvent>), type);
                _busClient.SubscribeAsync<TEvent>(
                    async @event => await _services.BuildServiceProvider().GetRequiredService<IEventConsumerWrapper>().ConsumeAsync(@event),
                    c => c.UseSubscribeConfiguration(b =>
                    {
                        b.FromDeclaredQueue(a => a.WithName($"{_consumerAssembly.GetName().Name}/{typeof(TEvent).Name}"));
                    }));

            }

            return this;
        }

        public IBusClient Build() => _busClient;
    }
}

