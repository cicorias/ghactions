using Microsoft.Extensions.Options;

namespace AsaHelperAction
{

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly StreamingJobOptions _options;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public Worker(ILogger<Worker> logger, IOptions<StreamingJobOptions> options, IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            _options = options.Value;
            _hostApplicationLifetime = hostApplicationLifetime;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Your primary work here
            _logger.LogInformation("Starting the primary work...");
            await DoWork(stoppingToken);

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

}