using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonServiceLocator;
using MassTransit;
using MassTransitTest;
using MassTransitTest.Consumers;
using MassTransitTest.Request;
using System.Reflection;
using TC.IOC.AutoFacEx;
using TC.MQ.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var cb = new ContainerBuilder();
cb.Populate(builder.Services);
cb.AddMassTransit(x =>
{
    // add all consumers in the specified assembly
    x.AddConsumers(Assembly.GetExecutingAssembly());

    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

});
cb.RegisterGenericRequestClient();
var _container = new AutoFacServiceLocator(cb);
_container.ScanAssembly<OrderSuccessConsumer>();

RegisterModule.Register(_container);
_container.UseAsDefault(true);
var bc = _container.GetInstance<IBusControl>();
bc.Start();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var config = new RabbitMQConfig { Host = "localhost:/Sensors", Password = "123456", Username = "admin" };
_container.BusOnRabbitMq(config, x => x.SubscribeAt(config.Host, new DefaultConsumeConfigurator(_container)));
_container.BusOnRabbitMq(config, x => x.PublishAt(config.Host, new DefaultConsumeConfigurator(_container)));

app.Run();


