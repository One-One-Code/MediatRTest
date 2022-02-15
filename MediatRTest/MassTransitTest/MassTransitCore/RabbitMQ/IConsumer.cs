using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.MQ.Common;

namespace TC.MQ.RabbitMQ
{
    public interface IEventConsumer<in T> : IConsumer
        where T : Event
    {
        void Consume(T eEvent);
    }
}
