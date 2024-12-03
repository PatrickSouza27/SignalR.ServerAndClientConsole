# SignalR

### Server

```bash
dotnet add package Microsoft.AspNet.SignalR
```
```csharp
class MyHub : Hub
{}

builder.Services.AddSignalR();

app.MapHub<MyHub>("/");
```

### Client

```bash
dotnet add package Microsoft.AspNet.SignalR.Client
```

