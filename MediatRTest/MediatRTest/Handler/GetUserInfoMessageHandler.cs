using MediatR;
using MediatRTest.Message;
using MediatRTest.Models;

namespace MediatRTest.Handler
{
    /// <summary>
    /// 定义获取用户信息的消息处理类
    /// 返回用户名密码
    /// </summary>
    public class GetUserInfoMessageHandler : RequestHandler<GetUserInfoMessage, UserInfoModel>
    {
        protected override UserInfoModel Handle(GetUserInfoMessage request)
        {
            return new UserInfoModel { UserName =request.UserName, Password = "123456" };
        }
    }
}
