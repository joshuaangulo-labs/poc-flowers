namespace Flowers.App.Workers;

/// <summary>
/// Sends notifications via email and SMS.
/// Handles delivery confirmations, reminders, and contact refresh campaigns.
/// </summary>
public class NotificationWorker : BackgroundService
{
    private readonly ILogger<NotificationWorker> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

    public NotificationWorker(ILogger<NotificationWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("NotificationWorker starting");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessNotificationsAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing notifications");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

    private async Task ProcessNotificationsAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processing notification queue...");

        // TODO: Query pending notifications
        // TODO: Send emails via SendGrid/SES
        // TODO: Send SMS via Twilio
        // TODO: Track bounces and failures
        // TODO: Annual contact refresh reminders

        await Task.CompletedTask;
    }
}
