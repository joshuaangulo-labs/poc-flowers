namespace Flowers.App.Workers;

/// <summary>
/// Processes scheduled gifts and generates delivery events.
/// Runs on a rolling window to identify deliveries due within the next N days.
/// </summary>
public class ScheduleWorker : BackgroundService
{
    private readonly ILogger<ScheduleWorker> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(15);

    public ScheduleWorker(ILogger<ScheduleWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ScheduleWorker starting");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessSchedulesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing schedules");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

    private async Task ProcessSchedulesAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Checking for upcoming deliveries...");

        // TODO: Query schedules due within rolling window
        // TODO: Generate delivery events for due schedules
        // TODO: Mark schedules as processed

        await Task.CompletedTask;
    }
}
