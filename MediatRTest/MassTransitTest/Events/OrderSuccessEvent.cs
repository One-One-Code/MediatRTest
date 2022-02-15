using TC.MQ.Common;

namespace MassTransitTest.Events
{
    public class OrderSuccessEvent: Event
    {
        public override string RoutingKey => "OrderSuccess_Key";
        public override string ExchangeName => "OrderSuccess_Exchange";
        public override string ExchangeType => "direct";
        public override string QueueName => "OrderSuccess_Queue";

        public string OrderId { get; set; }
    }
}
