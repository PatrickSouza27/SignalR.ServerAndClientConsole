using Microsoft.AspNetCore.SignalR;

namespace NotificationServerSignalr;

public class NotificationHub : Hub<INotificationClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).ReceiveNotification($"Conexão feita com sucesso! {Context.User?.Identity?.Name}");
        
        await base.OnConnectedAsync();
    }
}