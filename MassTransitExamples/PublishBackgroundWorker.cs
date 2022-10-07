using MassTransit;
using MassTransitExamples.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MassTransitExamples;

public class PublishBackgroundWorker : BackgroundService
{
    private readonly IBus _bus;
    private ILogger<PublishBackgroundWorker> _logger;

    public PublishBackgroundWorker(IBus bus, ILogger<PublishBackgroundWorker> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
            
            await _bus.Publish<ITriggerEvent>(new { }, stoppingToken);
            
            _logger.LogInformation("Trigger message sent");
        }
    }
}