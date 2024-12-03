namespace ClientsSignalR;

using Microsoft.AspNetCore.SignalR.Client;

public class MiniSignalServerConsole
{
    public async Task Run()
    {
        var uri = "http://localhost:5249/chat";

        await using var connection = new HubConnectionBuilder().WithUrl(uri).Build();

        await connection.StartAsync();

        await foreach (var date in connection.StreamAsync<DateTime>("Streaming"))
        {
            Console.WriteLine(date);
        }
    }
}