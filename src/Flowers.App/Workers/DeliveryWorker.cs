namespace Flowers.App.Workers;

/// <summary>
/// Processes delivery events by orchestrating vendor API calls.
/// Handles retries with exponential backoff and escalates failures to exception queue.
/// </summary>
public class DeliveryWorker : BackgroundService
{
    private readonly ILogger<DeliveryWorker> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(5);

    public DeliveryWorker(ILogger<DeliveryWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("DeliveryWorker starting");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessDeliveriesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing deliveries");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

    private async Task ProcessDeliveriesAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processing pending deliveries...");

        // TODO: Query pending delivery events
        // TODO: Submit orders to vendor APIs (FTD, 1-800-Flowers, etc.)
        // TODO: Handle responses and update delivery status
        // TODO: Retry transient failures with backoff
        // TODO: Escalate terminal failures to exception queue

        await Task.CompletedTask;
    }
}
