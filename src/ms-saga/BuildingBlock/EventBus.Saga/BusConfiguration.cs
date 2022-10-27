using MassTransit.RabbitMqTransport;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBus.Messages.Configuration;

namespace EventBus.Saga
{
    public class BusConfiguration
    {
        public static class BusConfigurator
        {
            public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
            {
                return Bus.Factory.CreateUsingRabbitMq(factory =>
                {
                    factory.Host(BusConstants.RabbitMqUri, configurator =>
                    {
                        configurator.Username(BusConstants.UserName);
                        configurator.Password(BusConstants.Password);
                    });

                    registrationAction?.Invoke(factory);
                });
            }
        }
    }
}
