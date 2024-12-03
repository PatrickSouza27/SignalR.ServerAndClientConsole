using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<MyHub>("/chat");
app.Run();

class MyHub : Hub
{
    public async IAsyncEnumerable<DateTime> Send()
    {
        while (true)
        {
            await Task.Delay(1000);
            yield return DateTime.Now;
        }
    }
}