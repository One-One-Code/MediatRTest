using MediatR;
using MediatRTest.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeOrder2SuccessHandler : INotificationHandler<OrderPaySuccessMessage>
    {
        public Task Handle(OrderPaySuccessMessage notification, CancellationToken cancellationToken)
        {
            Task task = Task.Run(() => {
                Thread.Sleep(10 * 1000);
                Console.WriteLine($"{DateTime.Now.ToString()}ChangeOrder2SuccessHandler-{Thread.CurrentThread.ManagedThreadId}     ------        {notification.OrderId}"); }
              ) ;
            return task;
            //Console.WriteLine($"ChangeOrder2SuccessHandler-{Thread.CurrentThread.ManagedThreadId}     ------        {notification.OrderId}");
            //return Task.CompletedTask;
        }
    }
}
