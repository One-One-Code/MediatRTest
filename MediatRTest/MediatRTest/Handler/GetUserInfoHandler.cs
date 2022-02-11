using MediatRTest.Message;
using MediatRTest.Models;


namespace MediatRTest.Handler
{
    public class GetUserInfoHandler
    {
        public UserInfoModel Handle(GetUserInfoMessage request)
        {
            return new UserInfoModel { UserName = request.UserName, Password = "123456" };
        }
    }
}
