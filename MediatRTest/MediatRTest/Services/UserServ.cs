using Grpc.Core;
using MediatR;
using MediatRTest.Message;
using System;
using System.Collections.Generic;
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

        public override Task<GetUserStatusOutput> GetUserStatus(GetUserStatusInput request, ServerCallContext context)
        {
            if (!string.IsNullOrEmpty(request.Token))
            {
                Console.WriteLine($"入口-{Thread.CurrentThread.ManagedThreadId}     ------        {request.Token}");
                mediator.Send(new RegisterSuccessMessage() { Id = request.Token });
                mediator.Publish(new OrderPaySuccessMessage { OrderId = "11222" });
                return Task.FromResult(new GetUserStatusOutput { IsNormal = true });
            }
            return Task.FromResult(new GetUserStatusOutput { IsNormal = false });
        }

        public override Task<LoginOutput> Login(LoginInput request, ServerCallContext context)
        {
            var userInfo = mediator.Send(new GetUserInfoMessage { UserName = request.Name });
            if (request.Name.Equals(userInfo.Result.UserName) && request.Password.Equals(userInfo.Result.Password))
            {
                return Task.FromResult(new LoginOutput { Token = $"{request.Name}{request.Password}" });
            }
            return Task.FromResult(new LoginOutput { Token = string.Empty });
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
