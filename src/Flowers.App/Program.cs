using Flowers.App;
using Flowers.App.Workers;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting Flowers.App worker service");

    var builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddSerilog();

    // Register workers
    builder.Services.AddHostedService<ScheduleWorker>();
    builder.Services.AddHostedService<DeliveryWorker>();
    builder.Services.AddHostedService<NotificationWorker>();

    var host = builder.Build();
    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
