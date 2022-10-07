using MassTransit;
using MassTransitExamples;
using MassTransitExamples.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(configurator =>
        {
            // configurator.UsingRabbitMq((context, factoryConfigurator) =>
            // {
            //     factoryConfigurator.Host("", hostConfigurator =>
            //     {
            //         hostConfigurator.Username("");
            //         hostConfigurator.Password("");
            //     });
            // });
            
            configurator.UsingInMemory((context, factoryConfigurator) =>
            {
                factoryConfigurator.ConfigureEndpoints(context);
            });
            
            configurator.AddConsumers(typeof(TriggerConsumer).Assembly);
        });
        
        services.AddHostedService<PublishBackgroundWorker>();
    })
    .Build();

host.Run();