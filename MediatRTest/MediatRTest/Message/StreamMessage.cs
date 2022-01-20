using MediatR;
using System;

namespace MediatRTest.Message
{
    public class StreamMessage: IStreamRequest<Meeting>
    {
    }

    public class Meeting
    {
        public string Id=>Guid.NewGuid().ToString("n");

        public DateTime Time = DateTime.Now;

        public string Title { get; set; }

        public override string ToString()
        {
            return $"会议室{Id}将在{Time}开始主题为{Title}的会议";
        }
    }
}
