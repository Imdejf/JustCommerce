using JustCommerce.Application.Models.MessageBus.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Interfaces.CommonServices.MessageBus
{
    public interface IMessageBusConnectionBuilder<TBusClient>
    {
        IMessageBusConnectionSetAssemblyBuilder<TBusClient> ApplyConfiguration(IConfigurationSection section);
        TBusClient Build();
    }

    public interface IMessageBusConnectionSetAssemblyBuilder<TBusClient>
    {
        IMessageBusConnectionSubscribeToEventBuilder<TBusClient> RegisterConsumers(Assembly assembly);
    }

    public interface IMessageBusConnectionSubscribeToEventBuilder<TBusClient>
    {
        IMessageBusConnectionSubscribeToEventBuilder<TBusClient> SubscribeToEvent<TEvent>() where TEvent : BaseNotificationEvent;
        TBusClient Build();
    }
}
