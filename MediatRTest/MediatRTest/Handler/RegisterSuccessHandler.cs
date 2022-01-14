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
        protected override async Task Handle(RegisterSuccessMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"消息1-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Id}");
            await Write(request);
        }
        private Task Write(RegisterSuccessMessage request)
        {
            Task task = Task.Run(() =>
            Console.WriteLine($"消息2-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Id}"));
            return task;
        }
    }
}
