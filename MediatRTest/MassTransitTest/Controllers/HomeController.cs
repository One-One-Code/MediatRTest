using CommonServiceLocator;
using MassTransit;
using MassTransitTest.Events;
using MassTransitTest.Request;
using Microsoft.AspNetCore.Mvc;
using TC.MQ.RabbitMQ;

namespace MassTransitTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //IRequestClient<LoginSuccessRequest> _client;
        public HomeController()
        {
           // _client = client;
        }

        [HttpPost(Name ="Login")]
        public bool Login([FromBody] LoginRequest request)
        {
            var _client= ServiceLocator.Current.GetInstance<IRequestClient<LoginSuccessRequest>>();
            var success= _client.GetResponse<LoginSuccessResponse>(new LoginSuccessRequest { UserId="222"}).Result.Message.CouponSended;
            if (success)
            {
                var publisher=ServiceLocator.Current.GetInstance<IEventPublisher>();
                publisher.Publish(new OrderSuccessEvent { OrderId = "111" });
            }
            return success;
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
