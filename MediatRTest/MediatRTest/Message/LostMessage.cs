using MediatR;

namespace MediatRTest.Message
{
    /// <summary>
    /// 定义一个消息
    /// </summary>
    public class LostMessage : IRequest
    {
        public string UserID { get; set; }
    }
}
