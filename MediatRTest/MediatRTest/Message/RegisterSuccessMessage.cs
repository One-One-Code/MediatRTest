using MediatR;

namespace MediatRTest.Message
{
    /// <summary>
    /// 定义一个消息不需要返回结果
    /// </summary>
    public class RegisterSuccessMessage: IRequest
    {
        public string Id { get; set; }
    }
}
