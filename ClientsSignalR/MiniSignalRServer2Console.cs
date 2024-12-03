using Microsoft.AspNetCore.SignalR.Client;

namespace ClientsSignalR;

public class MiniSignalRServer2Console
{ 
    public async Task Run()
    {
        
        Console.WriteLine("Inicializando o cliente SignalR...");
        
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7157/notification")
            .Build();
        
        connection.On<string>("ConnectionSuccess", (message) =>
        {
            Console.WriteLine($"{message}");
        });
        
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
             Console.WriteLine($"{user}: {message}");
        });
        
        // try
        // {
               await connection.StartAsync();
        //     Console.WriteLine("Conectado ao servidor!");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"Erro ao conectar: {ex.Message}");
        // }
        //
        // Console.Write("Digite seu nome de usuário: ");
        // var user = Console.ReadLine();
        //
        // while (true)
        // {
        //     Console.Write("Digite a mensagem (ou 'exit' para sair): ");
        //     var message = Console.ReadLine();
        //     
        //     if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
        //         break;
        //     
        //     await connection.InvokeAsync("SendMessage", user, message);
        // }
        //
        // await connection.StopAsync();
        
        
        await Task.CompletedTask;
    }
}