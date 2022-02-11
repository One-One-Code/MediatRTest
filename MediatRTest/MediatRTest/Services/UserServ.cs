using Grpc.Core;
using MediatR;
using MediatRTest.Handler;
using MediatRTest.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TC.LoggerStandard;
using User;

namespace MediatRTest.Services
{
    public class UserServ : User.UserService.UserServiceBase
    {
        private readonly IMediator mediator;
        private readonly IA _a;
        private static List<string> lis = new List<string>();
        public UserServ(IMediator mediator, IA a)
        {
            this.mediator = mediator;
            _a = a;
        }

        public override async Task<GetUserStatusOutput> GetUserStatus(GetUserStatusInput request, ServerCallContext context)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                Console.WriteLine($"{DateTime.Now.ToString()}入口-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Token}");
                await mediator.Send(new RegisterSuccessMessage() { Id = request.Token });
                await mediator.Publish(new OrderPaySuccessMessage { OrderId = "11222" });
                var meetings=  mediator.CreateStream(new StreamMessage());
                await foreach (var item in  meetings)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}     ------        {item.ToString()}");
                }
                return new GetUserStatusOutput { IsNormal = true };
            }
            return new GetUserStatusOutput { IsNormal = false };
        }

        public override Task<LoginOutput> Login(LoginInput request, ServerCallContext context)
        {
            Test();
            var userInfo = mediator.Send(new GetUserInfoMessage { UserName = request.Name });
            if (request.Name.Equals(userInfo.Result.UserName) && request.Password.Equals(userInfo.Result.Password))
            {
                return Task.FromResult(new LoginOutput { Token = $"{request.Name}{request.Password}" });
            }
            return Task.FromResult(new LoginOutput { Token = string.Empty });
        }

        private void Test()
        {
            var watch = new Stopwatch();
            watch.Start();
            for(int i = 0; i < 100000; i++)
            {
                var userInfo = mediator.Send(new GetUserInfoMessage { UserName = "huang" });
            }
            watch.Stop();
            Console.WriteLine($"mediator:{watch.ElapsedMilliseconds}");

            
            watch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                var handler = new GetUserInfoHandler();
                var userInfo = handler.Handle(new GetUserInfoMessage { UserName = "huang" });
            }
            watch.Stop();
            Console.WriteLine($"handler:{watch.ElapsedMilliseconds}");
        }
    }

    public interface IA
    {
        string GetId();
    }

    public class A : IA
    {
        public string Name=>Guid.NewGuid().ToString("n");

        public string GetId()
        {
            return Name;
        }
    }
}
