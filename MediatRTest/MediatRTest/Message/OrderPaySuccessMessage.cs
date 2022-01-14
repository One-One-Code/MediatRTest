using MediatR;

namespace MediatRTest.Message
{
    /// <summary>
    ///通知消息
    /// </summary>
    public class OrderPaySuccessMessage: INotification
    {
        public string OrderId { get; set; }
    }
}
