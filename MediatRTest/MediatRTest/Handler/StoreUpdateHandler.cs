using MediatR;
using MediatRTest.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    /// <summary>
    /// 支付成功后，更新库存
    /// </summary>
    public class StoreUpdateHandler : INotificationHandler<OrderPaySuccessMessage>
    {
        public Task Handle(OrderPaySuccessMessage notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"StoreUpdateHandler-{Thread.CurrentThread.ManagedThreadId}     ------        {notification.OrderId}");
            return Task.CompletedTask;
        }
    }
}
