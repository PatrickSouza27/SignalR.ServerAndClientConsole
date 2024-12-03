using MiniSignalRServer2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/notification");

app.Run();