using MassTransitTest.Events;
using TC.MQ.RabbitMQ;

namespace MassTransitTest.Consumers
{
    public class OrderSuccessConsumer : IEventConsumer<OrderSuccessEvent>
    {
        public void Consume(OrderSuccessEvent eEvent)
        {
            
        }
    }
}
