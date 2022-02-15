using Autofac;
using CommonServiceLocator;
using MassTransit;
using MassTransitTest.Request;
using System.Reflection;
using TC.IOC.AutoFacEx;
using TC.MQ.Common;
using TC.MQ.RabbitMQ;

namespace MassTransitTest
{
    public class MassTransitFactory
    {
        private static IBusControl BusControl;
        static MassTransitFactory()
        {
           BusControl = ServiceLocator.Current.GetInstance<IBusControl>();
           BusControl.Start();
        }

        public static void Publish<T>(T @event) where T : IEvent
        {
            BusControl.Publish(@event).Wait();
        }

        public static void Send<T>(T @event) where T : IEvent
        {
            BusControl.Send(@event).Wait();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMassTransit(x =>
            {

                // add all consumers in the specified assembly
                x.AddConsumers(Assembly.GetExecutingAssembly());


                // add the bus to the container
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost:/Sensors"), h =>
                    {
                        h.Username("admin");
                        h.Password("123456");
                    });

                    cfg.ReceiveEndpoint("customer_update", ec =>
                    {
                        ec.ConfigureConsumers(context);

                    });

                    x.AddRequestClient<LoginSuccessRequest>();
                });
            });
            var _container = new AutoFacServiceLocator(builder);

            RegisterModule.Register(_container);
            _container.UseAsDefault(false);

            BusControl = _container.GetInstance<IBusControl>();
            BusControl.Start();

        }

    }
}
