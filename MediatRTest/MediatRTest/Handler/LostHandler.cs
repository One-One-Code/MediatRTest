using MediatR;
using MediatRTest.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    /// <summary>
    /// 同步事件
    /// </summary>
    public class LostHandler : RequestHandler<LostMessage>
    {
        //Task<bool> IRequestHandler<LostMessage, bool>.Handle(LostMessage request, CancellationToken cancellationToken)
        //{
        //    if (request.UserID.Equals("huang"))
        //    {
        //        return Task.FromResult(true);
        //    }
        //    return Task.FromResult(false);
        //}
        protected override void Handle(LostMessage request)
        {
            if (!request.UserID.Equals("huang"))
            {
                throw new Exception("not null");
            }
            
        }
    }
}
