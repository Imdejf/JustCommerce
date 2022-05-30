using JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus;
using JustCommerce.Infrastructure.Implementations.Common.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;

namespace JustCommerce.Infrastructure.DependencyInjection
{
    public static partial class DependencyIncection
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, Action<IMessageBusConnectionBuilder<IBusClient>> action)
        {
            services.AddTransient<IEventConsumerWrapper, EventConsumerWrapper>();
            var builderInstance = services.BuildServiceProvider().GetRequiredService<IMessageBusConnectionBuilder<IBusClient>>();
            action.Invoke(builderInstance);
            services.AddSingleton(builderInstance.Build());
            services.AddScoped<IMessageBusClient, MessageBusClient>();

            return services;
        }
    }
}
