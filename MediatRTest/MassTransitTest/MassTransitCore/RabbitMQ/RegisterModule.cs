using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.IOC.AutoFacEx;

namespace TC.MQ.RabbitMQ
{
    public class RegisterModule
    {
        public static void Register(IAutoFacRegistration reg)
        {
            reg.Map<IEventPublisher, EventPublisher>();
        }
    }
}
