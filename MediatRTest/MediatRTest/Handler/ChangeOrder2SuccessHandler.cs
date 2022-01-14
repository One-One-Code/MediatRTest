using MediatR;
using MediatRTest.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    public class ChangeOrder2SuccessHandler : INotificationHandler<OrderPaySuccessMessage>
    {
        public Task Handle(OrderPaySuccessMessage notification, CancellationToken cancellationToken)
        {
            Task task = Task.Run(() =>
               Console.WriteLine($"ChangeOrder2SuccessHandler-{Thread.CurrentThread.ManagedThreadId}     ------        {notification.OrderId}"));
            return task;
            //Console.WriteLine($"ChangeOrder2SuccessHandler-{Thread.CurrentThread.ManagedThreadId}     ------        {notification.OrderId}");
            //return Task.CompletedTask;
        }
    }
}
