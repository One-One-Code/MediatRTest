using MassTransit;
using MassTransitTest.Request;

namespace MassTransitTest.Consumers
{
    public class LoginSuccessHandler : IConsumer<LoginSuccessRequest>
    {
        public Task Consume(ConsumeContext<LoginSuccessRequest> context)
        {
            context.RespondAsync<LoginSuccessResponse>(new LoginSuccessResponse
            {
                CouponSended = true,
            }).Wait();
            return Task.CompletedTask;
        }
    }
}
