using MediatR;
using MediatRTest.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    /// <summary>
    /// 异步处理消息
    /// </summary>
    public class RegisterSuccessHandler : AsyncRequestHandler<RegisterSuccessMessage>
    {
        protected override Task Handle(RegisterSuccessMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}消息1-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Id}");
            Write(request);
            return Task.CompletedTask;
        }
        private Task Write(RegisterSuccessMessage request)
        {
            Task task = Task.Run(() => { 
                Thread.Sleep(10 * 1000); 
                Console.WriteLine($"{DateTime.Now.ToString()}消息2-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Id}"); }
           );
            return task;
        }
    }
}
