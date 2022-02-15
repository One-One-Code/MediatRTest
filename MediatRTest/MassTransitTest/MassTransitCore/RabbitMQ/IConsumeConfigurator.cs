using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.MQ.Common;

namespace TC.MQ.RabbitMQ
{
    public interface IConsumeConfigurator
    {
        void Configure(IRabbitMqReceiveEndpointConfigurator cfg, IRabbitMqBusFactoryConfigurator fcg, List<IConsumer> consumers);

        void ConfigurePublisher(IRabbitMqBusFactoryConfigurator fcg);
    }
}
