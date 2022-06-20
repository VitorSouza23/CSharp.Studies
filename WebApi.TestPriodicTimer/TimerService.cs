namespace WebApi.TestPriodicTimer;

public class TimerService : BackgroundService
{
    private readonly ILogger<TimerService> _logger;

    public TimerService(ILogger<TimerService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        PeriodicTimer periodicTimer = new(TimeSpan.FromSeconds(1));

        while(await periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Log on {Timer}", DateTime.Now.ToString("O"));
        }
    }
}
