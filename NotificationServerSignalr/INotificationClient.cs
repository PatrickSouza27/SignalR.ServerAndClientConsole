namespace NotificationServerSignalr;

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}