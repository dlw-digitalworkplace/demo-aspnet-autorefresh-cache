namespace Demo.AutoRefreshCache.Services
{
    public class UpdateCacheHostedService : BackgroundService
    {
        private int _executionCount = 0;
        private readonly IDataService _dataService;
        private readonly ILogger<UpdateCacheHostedService> _logger;

        public UpdateCacheHostedService(IDataService dataService, ILogger<UpdateCacheHostedService> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

            do
            {
                try
                {
                    _dataService.UpdateData();

                    _executionCount++;
                    _logger.LogInformation("Executed UpdateCacheHostedService - Count: {ExecutionCount}", _executionCount);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                            "Failed to execute UpdateCacheHostedService with exception message '{Message}'. Good luck next round!",
                            ex.Message
                    );
                }
            }
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken));
        }
    }
}