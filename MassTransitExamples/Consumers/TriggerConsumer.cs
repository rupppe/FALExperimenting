using MassTransit;
using MassTransitExamples.Messages;
using Microsoft.Extensions.Logging;

namespace MassTransitExamples.Consumers;

public class TriggerConsumerDefinition : ConsumerDefinition<TriggerConsumer>
{
    public TriggerConsumerDefinition()
    {
        EndpointName = "TriggerConsumer";
    }
}

public class TriggerConsumer : IConsumer<ITriggerEvent>
{
    private readonly ILogger<TriggerConsumer> _logger;

    public TriggerConsumer(ILogger<TriggerConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ITriggerEvent> context)
    {
        _logger.LogInformation("Trigger event consumed #1");
        
        return Task.CompletedTask;
    }
}