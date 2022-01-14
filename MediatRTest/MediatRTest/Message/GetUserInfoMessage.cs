using MediatR;
using MediatRTest.Models;

namespace MediatRTest.Message
{
    public class GetUserInfoMessage : IRequest<UserInfoModel>
    {
        public string UserName { get; set; }
    }
}
