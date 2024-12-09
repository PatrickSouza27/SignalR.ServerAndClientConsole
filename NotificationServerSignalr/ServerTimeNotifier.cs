using Microsoft.AspNetCore.SignalR;

namespace NotificationServerSignalr;

public class ServerTimeNotifier : BackgroundService
{
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
    private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);
    private readonly ILogger<NotificationHub> _logger;
    
    public ServerTimeNotifier(IHubContext<NotificationHub, INotificationClient> hubContext, ILogger<NotificationHub> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Period);
        
        while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            
            var message = $"Server time: {DateTime.Now:HH:mm:ss}";
            
            _logger.LogInformation("Executing {server} {Time}, {message}", nameof(ServerTimeNotifier), DateTime.Now, message);
            
            await _hubContext.Clients.All.ReceiveNotification(message);
        }
    }
}