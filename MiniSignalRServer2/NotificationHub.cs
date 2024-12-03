using Microsoft.AspNetCore.SignalR;

namespace MiniSignalRServer2;

public class NotificationHub : Hub
{
    public async Task SendMessagePrivate(string destinatarioId, string remetente, string mensagem)
    {
        await Clients.User(destinatarioId).SendAsync("SendMessagePrivate", destinatarioId, mensagem);
    }
    
    public async Task SendAll(string remetente, string mensagem)
    {
        await Clients.All.SendAsync("SendAll " + remetente, mensagem);
    }
    
    public async Task AllAnonymous(string mensagem)
    {
        await Clients.All.SendAsync(mensagem);
        //await Groups.AddToGroupAsync()
    }

    public override Task OnConnectedAsync()
    {
        // var userId = Context.GetHttpContext()?.Request.Query["user"];
        //
        // if (userId is not null)
        //     Context.Items["UserId"] = userId;
        //
        // return base.OnConnectedAsync();
        
        //Caller retorna ao usuario atual alguma informaçao
        Clients.Caller.SendAsync("ConnectionSuccess", "Conexão feita com sucesso!");
        return base.OnConnectedAsync();
    }
}