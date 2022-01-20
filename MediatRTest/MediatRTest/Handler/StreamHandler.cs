using MediatR;
using MediatRTest.Message;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTest.Handler
{
    public class StreamHandler : IStreamRequestHandler<StreamMessage, Meeting>
    {
        public async IAsyncEnumerable<Meeting> Handle(StreamMessage request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            yield return await Task.Run(() => new Meeting { Title = "评审会议" });
            yield return await Task.Run(() => new Meeting { Title = "技术讨论会议" });
            yield return await Task.Run(() => new Meeting { Title = "用例评审会议" });
            yield return await Task.Run(() => new Meeting { Title = "复盘会议" });
        }
    }
}
