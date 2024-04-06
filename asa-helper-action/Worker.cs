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
            LogOptions();
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

        // log to verbose all the values of options
        private void LogOptions()
        {
            _logger.LogInformation("JobName: {JobName}", _options.JobName);
            _logger.LogInformation("ResourceGroup: {ResourceGroup}", _options.ResourceGroup);
            _logger.LogInformation("Subscription: {Subscription}", _options.Subscription);
            _logger.LogInformation("JobQuery: {JobQuery}", _options.JobQuery);
            _logger.LogInformation("StartTime: {StartTime}", _options.StartTime);
        }
    }
}
