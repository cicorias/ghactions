namespace AsaHelperAction;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger, IOptions<ReplayOrdersOptions> options, IHostApplicationLifetime hostApplicationLifetime)
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Your primary work here
        _logger.LogInformation("Starting the primary work...");
        await DoPrimaryWork();

        // Stop the application after the work is done
        _logger.LogInformation("Stopping the application");
        _hostApplicationLifetime.StopApplication();
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        }
        await Task.Delay(1000, stoppingToken);
    }
}

