using MassTransit;
using MassTransitExamples.Messages;
using Microsoft.Extensions.Logging;

namespace MassTransitExamples.Consumers;

public class TriggerConsumer2Definition : ConsumerDefinition<TriggerConsumer2>
{
    public TriggerConsumer2Definition()
    {
        EndpointName = "TriggerConsumer2";
    }
}

public class TriggerConsumer2 : IConsumer<ITriggerEvent>
{
    private readonly ILogger<TriggerConsumer2> _logger;

    public TriggerConsumer2(ILogger<TriggerConsumer2> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ITriggerEvent> context)
    {
        _logger.LogInformation("Trigger event consumed #2");
        
        return Task.CompletedTask;
    }
}